using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules.Dto
{
    public class DayTimeSchedulesResponse :  CommonResponse
    {
        public List<DayTimeSchedulesDto> DayTimeZonesList { get; set; }
    }

    public class DayTimeSchedulesDto
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
