using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.AccountActivation
{
    public class AccountActivationCommand : IRequest<AccountActivationResponse>
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Token { get; set; }
		public string Email { get; set; }
		public string PictureData { get; set; }
	}
}
