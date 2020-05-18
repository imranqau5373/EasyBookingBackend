using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot.Dto
{
    public class BookedSlotCommand : IRequest<BookedSlotResponse>
    {

        public int SlotId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Phone { get; set; }



    }
}
