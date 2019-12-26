using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.DeleteCourts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.Dto.DeleteCourts
{
    public class DeleteCourtsCommand : IRequest<DeleteCourtsResponse>
    {
        public long Id { get; set; }
    }
}
