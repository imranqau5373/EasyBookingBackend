using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddDayTimeSchedule.Dto
{
    public class AddDayTimeResponse : CommonResponse
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
