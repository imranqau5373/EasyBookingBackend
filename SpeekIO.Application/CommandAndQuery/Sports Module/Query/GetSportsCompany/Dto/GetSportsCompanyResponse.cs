using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsCompany.Dto
{
	public class GetSportsCompanyResponse : CommonResponse
	{
		public List<SportsCompanyDto> CompanyList { get; set; }

	}
}
