using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto
{
    public class GetCourtsListResponse : CommonResponse
    {
        public List<GetCourtsListDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
