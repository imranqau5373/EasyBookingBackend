using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Application.Implementation
{
	public class TokenGenerator : ITokenGenerator
	{
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly SpeekIOContext _context;
		private readonly ApplicationRoleManager _roleManager;
		public TokenGenerator(
			IApplicationConfiguration applicationConfiguration,
			SpeekIOContext context,
			ApplicationRoleManager roleManager)
		{
			this._applicationConfiguration = applicationConfiguration;
			this._context = context;
			this._roleManager = roleManager;
		}
		public async Task<string> GenerateSignInTokenAsync(ApplicationUser user, List<Claim> roleClaims = null)
		{
			await Task.Delay(0);
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			if (roleClaims != null)
				claims.Union(roleClaims);

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
