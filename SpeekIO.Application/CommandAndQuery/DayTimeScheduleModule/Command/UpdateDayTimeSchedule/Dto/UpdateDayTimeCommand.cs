using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule.Dto
{
    public class UpdateDayTimeCommand : IRequest<UpdateDayTimeResponse>
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
