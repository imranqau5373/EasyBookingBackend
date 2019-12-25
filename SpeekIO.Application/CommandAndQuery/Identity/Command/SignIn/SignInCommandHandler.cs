using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
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
        private readonly SpeekIOContext _context;
        private readonly IApplicationConfiguration _applicationConfiguration;
        public SignInCommandHandler(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ITokenGenerator tokenGenerator,
            ILogger<SignInCommandHandler> logger,
			SpeekIOContext context,
            IApplicationConfiguration applicationConfiguration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenGenerator = tokenGenerator;
            this._logger = logger;
            _context = context;
            _applicationConfiguration = applicationConfiguration;
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
            var profile = await _context.Profiles.FirstOrDefaultAsync(t => t.Id == user.Id);
            if (profile == null)
            {
                return new SignInResponse()
                {
                    Successful = false,
                    Message = "Unable to sign in. Please try again."
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
                AuthenticationToken = token,
                UserName = user.UserName,
                PictureUrl = !string.IsNullOrEmpty(profile.PictureUrl) ?
                             $"{_applicationConfiguration.BaseProfilePictureUrl}/{profile.PictureUrl }" :
                             _applicationConfiguration.ProfilePicturePlaceholderUrl,
                AdminRole = "1"
            };
        }

    }
}
