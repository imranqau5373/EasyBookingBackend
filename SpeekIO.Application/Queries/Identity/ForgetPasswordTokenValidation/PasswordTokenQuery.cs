using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.Identity.ForgetPasswordTokenValidation
{
	public class PasswordTokenQuery : IRequest<PasswordTokenValidationResponse>
	{
		public string email { get; set; }

		public string token { get; set; }
	}
}
