using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto
{
	public class SportsListResponse : CommonResponse
	{

		public List<SportsListDto> Items { get; set; }
		public int TotalCount { get; set; }
	}
}
