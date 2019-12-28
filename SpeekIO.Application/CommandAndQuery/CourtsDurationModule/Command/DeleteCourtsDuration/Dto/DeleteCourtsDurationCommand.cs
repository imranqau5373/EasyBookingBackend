using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.DeleteCourtsDuration.Dto
{
    public class DeleteCourtsDurationCommand : IRequest<DeleteCourtsDurationResponse>
    {
        public long Id { get; set; }
    }
}
