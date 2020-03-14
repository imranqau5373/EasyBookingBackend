using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class SignInResponse : CommonResponse
    {
		public string AuthenticationToken { get; set; }

		public string UserName { get; set; }
		public string CompleteName { get; set; }

		public bool IsAdmin { get; set; }

		public string PictureUrl { get; set; }

		public string TimeZoneOffset { get; set; }

		public long? CompanyId { get; set; }

		public long? UserId { get; set; }

		public long? organizationUnitId { get; set; }
		public List<Claim> Permissions { get; set; }
	}
}
