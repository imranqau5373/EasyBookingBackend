using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
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
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly ILogger<SignInCommandHandler> _logger;

        public SignInCommandHandler(ApplicationUserManager userManager, ApplicationSignInManager signInManager,
            IApplicationConfiguration applicationConfiguration,
            ILogger<SignInCommandHandler> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._applicationConfiguration = applicationConfiguration;
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

            if (!signInResult.Succeeded)
            {
                return new SignInResponse()
                {
                    Successful = false,
                    Message = $"Unable to sign in"
                };
            }

            var token = GenerateJwtToken(user);
            return new SignInResponse
            {
                Successful = signInResult.Succeeded,
                AuthenticationToken = token
            };
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationConfiguration.AuthKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_applicationConfiguration.TokenExpiry);

            var token = new JwtSecurityToken(
                _applicationConfiguration.Issuer,
                _applicationConfiguration.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
