using MediatR;
using Microsoft.AspNetCore.Http;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<CommonResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        //public IFormFile ProfilePicture { get; set; }
    }
}
