using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.Guest
{
    public class CreateGuestUserCommandHandler : IRequestHandler<CreateGuestUserCommand, CreateGuestUserResponse>
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ApplicationUserManager _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly SpeekIOContext _context;
        private readonly ILogger<CreateGuestUserCommandHandler> _logger;

        public CreateGuestUserCommandHandler(AutoMapper.IMapper mapper,
            ApplicationUserManager userManager,
            ITokenGenerator tokenGenerator,
			SpeekIOContext context,
            ILogger<CreateGuestUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _context = context;
            _logger = logger;
        }
        public async Task<CreateGuestUserResponse> Handle(CreateGuestUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser guestUser = null;
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                guestUser = await _userManager.FindByEmailAsync(request.Email);
                if (null != guestUser && !await _userManager.IsInRoleAsync(guestUser, UserRoles.GuestUser.ToString()))
                    return new CreateGuestUserResponse()
                    {
                        Successful = false,
                        AlreadyExists = true,
                        Message = "User is registered with this email. SignIn Required"
                    };
            }

            if (null == guestUser)
            {
                guestUser = _mapper.Map<ApplicationUser>(request);
                var identityResult = await _userManager.CreateAsync(guestUser);
                if (!identityResult.Succeeded)
                    return CreateFailedResponse(identityResult);
                await AssignRoles(guestUser);

                await CreateProfile(guestUser);
            }


            var token = await _tokenGenerator.GenerateSignInTokenAsync(guestUser);

            return new CreateGuestUserResponse
            {
                Successful = true,
                AuthenticationToken = token
            };

        }

        private async Task<Profile> CreateProfile(ApplicationUser user)
        {
            var profile = _mapper.Map<Domain.Entities.Portfolio.Profile>(user);

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return profile;
        }


        private async Task AssignRoles(ApplicationUser user)
        {
            var roles = new List<string>();

            roles.Add(UserRoles.GuestUser.ToString());

            await _userManager.AddToRolesAsync(user, roles);
        }

        private CreateGuestUserResponse CreateFailedResponse(IdentityResult identityResult)
        {
            _logger.LogError("Error occured while creating user.");
            if (null != identityResult.Errors)
                foreach (var item in identityResult.Errors)
                    _logger.LogError($"Error occured while creating user. {item.Code}, {item.Description}");

            return new CreateGuestUserResponse
            {
                Successful = false,
                Data = identityResult
            };
        }
    }
}
