using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto
{
    public class GetCourtsBookingListResponse : CommonResponse
    {
        public List<GetCourtsBookingListDto> Items { get; set; }
        public int TotalCount { get; set; }
    }


    
}
