using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly ApplicationUserManager _userManager;
		private readonly ApplicationRoleManager _roleManager;
		private readonly ApplicationSignInManager _signInManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ILogger<SignInCommandHandler> _logger;
        private readonly SpeekIOContext _context;
        private readonly IApplicationConfiguration _applicationConfiguration;
        public SignInCommandHandler(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
			 ApplicationRoleManager roleManager,
			ITokenGenerator tokenGenerator,
            ILogger<SignInCommandHandler> logger,
			SpeekIOContext context,
            IApplicationConfiguration applicationConfiguration)
        {
            this._userManager = userManager;
			this._roleManager = roleManager;
			this._signInManager = signInManager;
            this._tokenGenerator = tokenGenerator;
            this._logger = logger;
            _context = context;
            _applicationConfiguration = applicationConfiguration;
        }
        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByEmailAsync(request.Email);
            //var companyId = await _context.Profiles
            //    .Where(u => u.UserId == user.Id)
            //    .Select(p => p.CompanyId ).FirstAsync();

			var userDetail = await _context.ApplicationUser
				.GroupJoin(_context.ApplicationUserRole.Where(t => !t.IsDeleted), u => u.Id, ur => ur.UserId,
				(u, ur) => new { u, ur })
				.FirstOrDefaultAsync(t => t.u.Email.ToLower().Trim() == request.Email.ToLower().Trim());

			if (userDetail == null || userDetail.u == null || userDetail.ur == null)
			{
				return new SignInResponse()
				{
					Successful = false,
					Message = "Unable to sign in. Please try again."
				};
			}

			var user = userDetail.u;

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
					Message = $"Unable to sign in. Please try again"
				};
			}
			var profile = await _context.Profiles.FirstOrDefaultAsync(t => t.UserId == user.Id && !t.IsDeleted);
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
					Message = $"Invalid email or password."
				};
			}

			var roleClaims = await GetRoleClaimsAsync(userDetail.ur.FirstOrDefault().RoleId);
			var token = await _tokenGenerator.GenerateSignInTokenAsync(user, roleClaims);
			string pictureUrl = null;
			var isAdmin = await _context.ApplicationUserRole.AnyAsync(t => t.RoleId == (long)UserRoles.Admin && t.UserId == user.Id && !t.IsDeleted);

			return new SignInResponse
			{
				Successful = signInResult.Succeeded,
				AuthenticationToken = token,
				UserName = user.UserName,
				CompleteName = profile.FirstName + " " + profile.LastName,
				CompanyId = profile.CompanyId,
				TimeZoneOffset = profile.Timezone,
				UserId = user.Id,
				//organizationUnitId = profile.OrganizationId,
				PictureUrl = pictureUrl,
				IsAdmin = isAdmin,
				Permissions = roleClaims
			};


			//if (null == user)
			//         {
			//             return new SignInResponse()
			//             {
			//                 Successful = false,
			//                 Message = $"Unable to find account with email {request.Email}"
			//             };
			//         }

			//         if (!user.EmailConfirmed)
			//         {
			//             return new SignInResponse()
			//             {
			//                 Successful = false,
			//                 Message = $"Email not confirmed"
			//             };
			//         }
			//         var profile = await _context.Profiles.FirstOrDefaultAsync(t => t.Id == user.Id);
			//         if (profile == null)
			//         {
			//             return new SignInResponse()
			//             {
			//                 Successful = false,
			//                 Message = "Unable to sign in. Please try again."
			//             };
			//         }

			//         var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

			//         if (!signInResult.Succeeded)
			//         {
			//             return new SignInResponse()
			//             {
			//                 Successful = false,
			//                 Message = $"Unable to sign in"
			//             };
			//         }

			//         var token = await _tokenGenerator.GenerateSignInTokenAsync(user);
			//         return new SignInResponse
			//         {
			//             Successful = signInResult.Succeeded,
			//             AuthenticationToken = token,
			//             UserName = user.UserName,
			//             PictureUrl = !string.IsNullOrEmpty(profile.PictureUrl) ?
			//                          $"{_applicationConfiguration.BaseProfilePictureUrl}/{profile.PictureUrl }" :
			//                          _applicationConfiguration.ProfilePicturePlaceholderUrl,
			//             AdminRole = "1",
			//             CompanyId = companyId,
			//             UserId = user.Id
			//         };
		}


		public async Task<List<Claim>> GetRoleClaimsAsync(long roleId)
		{
			var claims = new List<Claim>();
			var roles = await _context.Roles.Select(x => new UserRole
			{
				Id = x.Id,
				Name = x.Name,
				IsPublic = x.IsPublic,
				NormalizedName = x.NormalizedName,
				ConcurrencyStamp = x.ConcurrencyStamp
			}).Where(x => x.Id == roleId).FirstOrDefaultAsync();
			var claim = await _roleManager.GetClaimsAsync(roles);
			if (claim != null)
				claims.AddRange(claim);
			return claims;
		}

	}
}
