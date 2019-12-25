using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse.QueryResponse;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.GetProfile
{
    public class GetProfileHandler : CommandHandlerBase<GetProfileQuery, GetProfileResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationConfiguration _applicationConfiguration;
        public GetProfileHandler(
			SpeekIOContext context,
            IMapper mapper,
            ApplicationUserManager userManager,
            IHttpContextAccessor httpContextAccessor,
            IApplicationConfiguration applicationConfiguration) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _applicationConfiguration = applicationConfiguration;
        }
        public override async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var userId = User.Id;
            var profile = await _context.Profiles.Include(t => t.Company).FirstOrDefaultAsync(t => t.User.Id == userId);
            if (profile == null)
            {
                return new GetProfileResponse()
                {
                    Successful = false,
                    Message = "User not found."
                };
            }
            var response = _mapper.Map<GetProfileResponse>(profile);
            //prepare complete azure blob storage url if profile picture exists, otherwise set default placeholder image
            response.PictureUrl = !string.IsNullOrEmpty(response.PictureUrl) ?
                $"{_applicationConfiguration.BaseProfilePictureUrl}/{response.PictureUrl }" :
                _applicationConfiguration.ProfilePicturePlaceholderUrl;

            response.CompanyName = profile.Company != null ? profile.Company.Name : "";
            response.Successful = true;
            return response;
        }
    }
}
