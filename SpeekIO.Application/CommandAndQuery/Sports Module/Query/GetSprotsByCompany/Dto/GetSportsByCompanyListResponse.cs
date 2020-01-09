using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList.Dto
{
	public class GetSportsByCompanyListResponse : CommonResponse
	{

		public List<GetSportsByCompanyListDto> SportsList { get; set; }
	}
}
