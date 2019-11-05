using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Common.Helpers;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.UpdateProfile
{
    public class UpdateProfileHandler : CommandHandlerBase<UpdateProfileCommand, CommonResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationConfiguration _applicationConfiguration;
        public UpdateProfileHandler(
            ISpeekIODbContext context,
            ApplicationUserManager userManager,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IApplicationConfiguration applicationConfiguration) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _applicationConfiguration = applicationConfiguration;
        }
        public override async Task<CommonResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _context.Profiles.Include(t => t.Company).FirstOrDefaultAsync(t => t.User.Id == User.Id);
            if (profile == null)
            {
                return CommonResponse.CreateFailedResponse<CommonResponse>("Profile not found");
            }
            var success = FileUploadHelper.UploadBase64File(request.ProfilePicture, _applicationConfiguration.ProfileImagePath, Convert.ToString(profile.Id));

            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.Company.Name = request.CompanyName;
            profile.Email = request.Email;
            profile.Phone = request.Phone;
            await _context.SaveChangesAsync(User);

            if (!success)
            {
                return CommonResponse.CreateFailedResponse<CommonResponse>("Something went wrong while updating the profile picture.");
            }

            return CommonResponse.CreateSuccessResponse<CommonResponse>("Profile updated successfully.");
        }
    }
}
