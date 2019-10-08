using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
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

        public AccountActivationCommandHandler(ApplicationUserManager userManager,
            IMapper mapper,
            IEmailService emailService,
            ILogger<AccountActivationCommandHandler> logger)
        {
            this._userManager = userManager;
            this._emailService = emailService;
            this._logger = logger;
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

            var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, request.ActivationToken);

            return new AccountActivationResponse
            {
                Successful = confirmEmailResult.Succeeded
            };
        }
    }
}
