using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule.Dto
{
    public class GetDayTimeScheduleQuery : IRequest<GetDayTimeScheduleReponse>
    {
        public long Id { get; set; }

    }
}
