using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto
{
	public class GetSportsListDto
	{

		public long Id { get; set; }
		public string Name { get; set; }
		public int CourtCount { get; set; }
		public DateTime? LastUpdated { get; set; }
		public string CreatedBy { get; set; }

		public bool? IsDeletedCourt { get; set; }
	}
}
