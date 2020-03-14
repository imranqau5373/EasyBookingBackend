using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.SignUp
{
    public class SignupCommandHandler : IRequestHandler<SignupCommand, SignupResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly SpeekIOContext _context;
        private readonly IEmailService _emailService;
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly ILogger<SignupCommandHandler> _logger;

        public SignupCommandHandler(ApplicationUserManager userManager,
            IMapper mapper,
			SpeekIOContext context,
            IEmailService emailService,
            IApplicationConfiguration applicationConfiguration,
            ILogger<SignupCommandHandler> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
            _applicationConfiguration = applicationConfiguration;
            _logger = logger;
        }

        public async Task<SignupResponse> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("A new user is signing up");

                var user = await _userManager.FindByEmailAsync(request.Email);
                if (null != user)
                    return CreateAlreadyExistsResponse();

                user = _mapper.Map<ApplicationUser>(request);
                user.LockoutEnabled = true;
				user.EmailConfirmed = true;

				//company url validation. same url is already exist or not.

				var company = await _context.Companies.Where(x => x.Url == request.CompanyPrivateUrl).FirstOrDefaultAsync();
				if (company != null)
					return CreateFailedOther("Company private url already exist.");

				var identityResult = await _userManager.CreateAsync(user, request.Password);
                if (!identityResult.Succeeded || 0 >= user.Id)
                    return CreateFailedResponse(identityResult);



				_logger.LogInformation("Successfully created user");

                await AssignRoles(user);

                var profile = await CreateProfile(request, user);

                await _userManager.UpdateAsync(user);

                //await SendActivationEmail(user);

                return new SignupResponse()
                {
                    Successful = true,
                    Message = "Successfully created user"
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while creating user", e);

                return new SignupResponse
                {
                    Successful = false,
                    Message = e.Message,
                    Data = e
                };
            }
        }

        private async Task<Domain.Entities.Portfolio.Profile> CreateProfile(SignupCommand request, ApplicationUser user)
        {
            var company = _mapper.Map<Company>(request);
            var profile = _mapper.Map<Domain.Entities.Portfolio.Profile>(request);
            profile.Id = user.Id;
            profile.User = user;
            profile.Company = company;

            company.Profiles.Add(profile);
            _context.Companies.Add(company);

            await _context.SaveChangesAsync(user);

            return profile;
        }

        private async Task SendActivationEmail(ApplicationUser user)
        {
            var activationUrl = $"https://{_applicationConfiguration.Domain}/Account/Activate?email={user.Email}&token={await _userManager.GenerateEmailConfirmationTokenAsync(user)}";
            IRecipient recipient = new Recipient(user.UserName, user.Email);
            IEmailModel emailModel = new AccountActivationEmailModel(activationUrl, recipient);

            await _emailService.SendEmailAsync(emailModel);
        }

        private async Task AssignRoles(ApplicationUser user)
        {
            var roles = new List<string>();
			roles.Add("Super Admin");
			//roles.Add(UserRoles.Admin.ToString());
			//roles.Add(UserRoles.HRManager.ToString());
			//roles.Add(UserRoles.User.ToString());

			await _userManager.AddToRolesAsync(user, roles);
        }

        private SignupResponse CreateAlreadyExistsResponse()
        {
            return new SignupResponse
            {
                Successful = false,
                IsAlreadyRegistered = true
            };
        }

        private SignupResponse CreateFailedResponse(IdentityResult identityResult)
        {
            _logger.LogError("Error occured while creating user.");
            if (null != identityResult.Errors)
                foreach (var item in identityResult.Errors)
                    _logger.LogError($"Error occured while creating user. {item.Code}, {item.Description}");

            return new SignupResponse
            {
                Successful = false,
                Data = identityResult
            };
        }

		private SignupResponse CreateFailedOther(string message)
		{
			_logger.LogError("Error occured while creating user.");
					_logger.LogError($"Error occured while creating user. { message}");

			return new SignupResponse
			{
				Successful = false,
				Message = message
			};
		}
	}
}
