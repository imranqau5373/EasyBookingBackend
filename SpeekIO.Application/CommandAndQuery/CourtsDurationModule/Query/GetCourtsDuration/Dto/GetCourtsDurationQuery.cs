using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto
{
    public class GetCourtsDurationQuery : IRequest<GetCourtsDurationResponse>
    {
        public long Id { get; set; }
    }
}
