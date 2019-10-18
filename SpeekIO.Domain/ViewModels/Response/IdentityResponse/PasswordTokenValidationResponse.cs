using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
	public class PasswordTokenValidationResponse : CommonResponse
	{
		public bool tokenValidation { get; set; }

		public bool emailValidation { get; set; } 
	}
}
