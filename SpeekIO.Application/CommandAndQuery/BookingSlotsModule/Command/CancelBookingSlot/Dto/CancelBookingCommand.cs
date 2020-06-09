using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.CancelBookingSlot.Dto
{
    public class CancelBookingCommand : IRequest<CancelBookingResponse>
    {
        public int SlotId { get; set; }

        public string CancelMessage { get; set; }
    }
}
