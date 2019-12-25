using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Interfaces.UploadService;
using SpeekIO.Common.Extensions;
using SpeekIO.Common.Helpers;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Models.UploadService;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.UpdateProfile
{
    public class UpdateProfileHandler : CommandHandlerBase<UpdateProfileCommand, CommonResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly IUploadService _uploadService;
        public UpdateProfileHandler(
			SpeekIOContext context,
            ApplicationUserManager userManager,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IApplicationConfiguration applicationConfiguration,
            IUploadService uploadService) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _applicationConfiguration = applicationConfiguration;
            _uploadService = uploadService;
        }
        public override async Task<CommonResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _context.Profiles.Include(t => t.Company).FirstOrDefaultAsync(t => t.User.Id == User.Id);
            if (profile == null)
            {
                return CommonResponse.CreateFailedResponse<CommonResponse>("Profile not found");
            }

            string fileNameWithExtension = null;
            //storing profile picture to azure blob storage
            if (!string.IsNullOrEmpty(request.ProfilePicture))
            {
                var uploadFileModel = new UploadFileModel();
                uploadFileModel.FileNameWithExtension = Convert.ToString(profile.Id) + "." + _applicationConfiguration.DefaultFileExtension;
                uploadFileModel.File = request.ProfilePicture.GetByteArrayFromBase64();
                uploadFileModel.BlobContainerName = _applicationConfiguration.UserAccountsContainerName;
                await _uploadService.UploadFileAsync(uploadFileModel);
                fileNameWithExtension = uploadFileModel.FileNameWithExtension;
            }

            //upload thumbnail
            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.Company.Name = request.CompanyName;
            profile.Email = request.Email;
            profile.Phone = request.Phone;
            //if picture is not changed from front end then no need to update this field
            profile.PictureUrl = !string.IsNullOrEmpty(fileNameWithExtension) ? fileNameWithExtension : null;
            await _context.SaveChangesAsync(User);

            //if picture was uplaoded from front end and didn't saved
            if (request.ProfilePicture != null && fileNameWithExtension == null)
            {
                return CommonResponse.CreateFailedResponse<CommonResponse>("Something went wrong while updating the profile picture.");
            }

            return CommonResponse.CreateSuccessResponse<CommonResponse>("Profile updated successfully.");
        }
    }
}
