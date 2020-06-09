using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.OpenBookedSlot.Dto
{
    public class OpenBookedSlotCommand : IRequest<OpenBookedSlotResponse>
    {

        public int SlotId { get; set; }
    }
}
