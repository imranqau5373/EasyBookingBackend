using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.AccountActivation
{
    public class AccountActivationCommandHandler : IRequestHandler<AccountActivationCommand, AccountActivationResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<AccountActivationCommandHandler> _logger;
		private readonly SpeekIOContext _context;
		private readonly IApplicationConfiguration _applicationConfiguration;

		public AccountActivationCommandHandler(ApplicationUserManager userManager,
            IMapper mapper,
            IEmailService emailService,
			SpeekIOContext context,
			   IApplicationConfiguration applicationConfiguration,
			ILogger<AccountActivationCommandHandler> logger)
        {
            this._userManager = userManager;
            this._emailService = emailService;
			_applicationConfiguration = applicationConfiguration;
			this._logger = logger;
			_context = context;
		}

        public async Task<AccountActivationResponse> Handle(AccountActivationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (null == user)
                return new AccountActivationResponse()
                {
                    Successful = false,
                    Message = $"Unable to find user with email {request.Email}"
                };

			var profile = await _context.Profiles.FirstOrDefaultAsync(t => t.UserId == user.Id);
			if (profile == null)
				return new AccountActivationResponse()
				{
					Successful = false,
					Message = $"Unable to find user with email {request.Email}"
				};
			var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, request.Token);
			if (confirmEmailResult.Succeeded)
			{
				var result = await _userManager.ChangePasswordAsync(user, _applicationConfiguration.DefaultPassword, request.Password);
				profile.FirstName = request.FirstName;
				profile.LastName = request.LastName;
				profile.Phone = request.Phone;
				await _context.SaveChangesAsync(user);
			}
			return new AccountActivationResponse
			{
				Successful = confirmEmailResult.Succeeded
			};
		}
    }
}
