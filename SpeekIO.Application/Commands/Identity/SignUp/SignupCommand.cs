using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.SignUp
{
    public class SignupCommand : IRequest<SignupResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPrivateUrl { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Timezone { get; set; }
        public bool SubscribeNewsLetter { get; set; }
    }
}
