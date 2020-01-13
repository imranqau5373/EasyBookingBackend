using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsBySportCompany.Dto
{
    public class GetCourtsBySportCompanyListResponse : CommonResponse
    {
        public List<GetCourtsBySportCompanyListDto> CourtsList { get; set; }
    }
}
