using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ILogger<SignInCommandHandler> _logger;

        public SignInCommandHandler(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ITokenGenerator tokenGenerator,
            ILogger<SignInCommandHandler> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenGenerator = tokenGenerator;
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

            if (!user.EmailConfirmed)
            {
                return new SignInResponse()
                {
                    Successful = false,
                    Message = $"Email not confirmed"
                };
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            if (!signInResult.Succeeded)
            {
                return new SignInResponse()
                {
                    Successful = false,
                    Message = $"Unable to sign in"
                };
            }

            var token = await _tokenGenerator.GenerateSignInTokenAsync(user);
            return new SignInResponse
            {
                Successful = signInResult.Succeeded,
                AuthenticationToken = token
            };
        }

    }
}
