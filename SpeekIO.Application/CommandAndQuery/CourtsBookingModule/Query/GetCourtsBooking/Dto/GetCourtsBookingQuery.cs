using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto
{
    public class GetCourtsBookingQuery : IRequest<GetCourtsBookingResponse>
    {
        public long Id { get; set; }
    }
}
