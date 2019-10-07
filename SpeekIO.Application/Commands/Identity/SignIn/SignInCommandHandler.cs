using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly ILogger<SignInCommandHandler> _logger;

        public SignInCommandHandler(ApplicationUserManager userManager, ApplicationSignInManager signInManager,
            ILogger<SignInCommandHandler> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
        }
        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (null == user)
            {
                return new SignInResponse()
                {
                    Successful = false,
                    Message = $"Unable to find account with email {request.Email}"
                };
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            return new SignInResponse
            {
                Successful = signInResult.Succeeded,
            };
        }
    }
}
