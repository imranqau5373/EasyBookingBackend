using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules.Dto
{
    public class DayTimeSchedulesQuery : IRequest<DayTimeSchedulesResponse>
    {
    }
}
