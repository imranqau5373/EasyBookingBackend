using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationList.Dto
{
    public class GetCourtsDurationListResponse : CommonResponse
    {
        public List<GetCourtsDurationListDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
