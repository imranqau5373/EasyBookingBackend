using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.ListDayTimeSchedule.Dto
{
    public class ListDayTimeScheduleResponse :  CommonResponse
    {
        public List<ListDayTimeScheduleDto> Items { get; set; }
        public int TotalCount { get; set; }

    }
}
