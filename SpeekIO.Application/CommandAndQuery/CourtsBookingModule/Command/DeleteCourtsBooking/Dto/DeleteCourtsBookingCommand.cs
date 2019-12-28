using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking.Dto
{
    public class DeleteCourtsBookingCommand : IRequest<DeleteCourtsBookingResponse>
    {
        public long Id { get; set; }
    }
}
