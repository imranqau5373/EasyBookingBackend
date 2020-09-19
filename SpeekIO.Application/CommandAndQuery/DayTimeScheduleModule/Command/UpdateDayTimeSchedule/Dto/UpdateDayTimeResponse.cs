using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule.Dto
{
    public class UpdateDayTimeResponse : CommonResponse
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
