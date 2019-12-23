using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto
{
	public class AddSportsResponse : CommonResponse
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CompanyId { get; set; }
	}
}
