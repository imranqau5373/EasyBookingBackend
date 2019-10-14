using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Application.Implementation
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public TokenGenerator(IApplicationConfiguration applicationConfiguration)
        {
            this._applicationConfiguration = applicationConfiguration;
        }
        public async Task<string> GenerateSignInTokenAsync(ApplicationUser user)
        {
            await Task.Delay(0);
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
