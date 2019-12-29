using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto
{
    public class UpdateCourtsBookingCommand : IRequest<UpdateCourtsBookingResponse>
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? CourtId { get; set; }
        public long? UserId { get; set; }
        public DateTime? BookingStartTime { get; set; }
        public DateTime? BookingEndTime { get; set; }
        public bool IsBooked { get; set; }
        public bool IsEmailed { get; set; }
    }
}
