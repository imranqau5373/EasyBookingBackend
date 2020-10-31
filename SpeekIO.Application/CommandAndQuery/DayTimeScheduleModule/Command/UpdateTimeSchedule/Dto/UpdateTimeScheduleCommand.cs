using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateTimeSchedule.Dto
{
    public class UpdateTimeScheduleCommand : IRequest<UpdateTimeScheduleResponse>
    {

        public int Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long DayTimeScheduleId { get; set; }

        public long Id { get; set; }
    }
}
