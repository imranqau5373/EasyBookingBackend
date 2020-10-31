using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddTimeSchedule.Dto
{
    public class AddTimeScheduleCommand : IRequest<AddTimeScheduleResponse>
    {

        public int Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long DayTimeScheduleId { get; set; }
    }
}
