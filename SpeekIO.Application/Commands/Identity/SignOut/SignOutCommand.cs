using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.SignOut
{
	public class SignOutCommand : IRequest<SignInResponse>
	{

		public string userToken { get; set; }
	}
}
