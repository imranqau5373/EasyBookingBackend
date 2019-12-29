using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto
{
    public class GetCompanyListResponse : CommonResponse
    {
        public List<GetCompanyListDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
