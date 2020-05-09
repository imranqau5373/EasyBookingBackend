using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot.Dto
{
    public class DetailSlotCommand : IRequest<DetailSlotReponse>
    {

        public int SlotId { get; set; }
    }
}
