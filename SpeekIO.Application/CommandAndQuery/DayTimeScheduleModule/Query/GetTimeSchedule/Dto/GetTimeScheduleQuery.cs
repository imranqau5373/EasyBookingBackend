using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetTimeSchedule.Dto
{
    public class GetTimeScheduleQuery : IRequest<GetTimeScheduleResponse>
    {

        public long Id { get; set; }
    }
}
