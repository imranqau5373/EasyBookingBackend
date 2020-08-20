using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Identity.Command.AddGuestUser.Dto;
using EasyBooking.Common.Session;
using EasyBooking.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EasyBooking.Application.CommandAndQuery.Identity.Command.AddGuestUser
{
    public class AddGuestUserCommandHandler : IRequestHandler<AddGuestUserCommand, AddGuestUserResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IEmailService _emailService;
		private readonly ApplicationUserManager _userManager;

		public AddGuestUserCommandHandler(
			 SpeekIOContext context,
			IMapper mapper,
			IEmailService emailService,
			IUserSession userSession,
			IApplicationConfiguration applicationConfiguration,
			ApplicationUserManager userManager,
			IHttpContextAccessor httpContextAccessor) 
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
			_applicationConfiguration = applicationConfiguration;
			_emailService = emailService;
			_userManager = userManager;
		}
		public async Task<AddGuestUserResponse> Handle(AddGuestUserCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var existingUser = await _userManager.FindByEmailAsync(request.Email);
				if (existingUser != null)
					return new AddGuestUserResponse()
					{
						Successful = false,
						Message = "Email already exists."
					};

				var user = _mapper.Map<ApplicationUser>(request);
				user.LockoutEnabled = true;
				user.UserName = request.Email;

				var identityResult = await _userManager.CreateAsync(user, _applicationConfiguration.DefaultPassword);
				if (!identityResult.Succeeded || 0 >= user.Id)
					return new AddGuestUserResponse()
					{
						Successful = false,
						Message = "Something went wrong while creating a user."
					};
				await AssignRoles(user, request);
				await CreateProfile(request, user);
				await SendActivationEmail(user);
				return new AddGuestUserResponse()
				{
					Successful = true,
					Message = "Account activation email sent successfully. Please check your email."
				};
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		//method to assign roles to user
		private async Task AssignRoles(ApplicationUser user, AddGuestUserCommand request)
		{
			var roles = new List<string>();
			request.SelectedRoles.ForEach(item =>
			{
				roles.Add(item.Name);
			});

			await _userManager.AddToRolesAsync(user, roles);
			await _userManager.UpdateAsync(user);
		}

		//method to create profile for user
		private async Task CreateProfile(AddGuestUserCommand request, ApplicationUser user)
		{
			try
			{
				var profile = _mapper.Map<SpeekIO.Domain.Entities.Portfolio.Profile>(request);
				profile.Id = user.Id;
				profile.UserId = user.Id;
				if (_userSession.CompanyId <= 0)
					profile.CompanyId = _context.Profiles.Where(x => x.Email == _applicationConfiguration.DefaultCompanyEmail).FirstOrDefault().CompanyId;
				profile.CompanyId = _userSession.CompanyId;
				_context.Profiles.Add(profile);
				await _context.SaveChangesAsync();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		//method to send activation email
		private async Task SendActivationEmail(ApplicationUser user)
		{
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var activationUrl = $"{_applicationConfiguration.ClientAppUrl}/{_applicationConfiguration.EmailVerificationPageUrl}?email={user.Email}&token={HttpUtility.UrlEncode(token)}";
			IRecipient recipient = new Recipient(user.UserName, user.Email);
			IEmailModel emailModel = new AccountActivationEmailModel(activationUrl, recipient);
			emailModel.TemplateName = "AccountActivationWithLink";
			await _emailService.SendEmailAsync(emailModel);
		}
	}
}
