using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule.Dto
{
    public class GetDayTimeScheduleReponse :  CommonResponse
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
