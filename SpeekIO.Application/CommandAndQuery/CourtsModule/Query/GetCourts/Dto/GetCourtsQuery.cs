using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts.Dto
{
    public class GetCourtsQuery : IRequest<GetCourtsResponse>
    {
        public long Id { get; set; }
    }
}
