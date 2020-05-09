using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot.Dto
{
    public class BookedSlotCommand : IRequest<BookedSlotResponse>
    {

        public int SlotId { get; set; }
    }
}
