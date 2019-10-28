using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.CandidateTest
{
	public class VideoQeustionResponse : CommonResponse
	{
		public string ApiKey { get; set; }

		public string SessionId { get; set; }

		public string Token { get; set; }
	}
}
