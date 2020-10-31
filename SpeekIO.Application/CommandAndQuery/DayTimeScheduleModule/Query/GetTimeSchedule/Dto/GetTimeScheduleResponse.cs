using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetTimeSchedule.Dto
{
    public class GetTimeScheduleResponse : CommonResponse
    {

        public TimeScheduleResponseData[] timeScheduleReponse { get; set; }
    }
    public class TimeScheduleResponseData
    {
        public string startTime { get; set; }

        public string endTime { get; set; }

        public int Day { get; set; }

        public long Id { get; set; }
    }
}
