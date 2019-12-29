using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto
{
	public class GetSportsListResponse : CommonResponse
	{

		public List<GetSportsListDto> Items { get; set; }
		public int TotalCount { get; set; }
	}
}
