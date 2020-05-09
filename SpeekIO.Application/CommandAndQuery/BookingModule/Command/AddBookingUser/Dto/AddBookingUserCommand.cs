using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Command.AddBookingUser.Dto
{
    public class AddBookingUserCommand : IRequest<AddBookingUserResponse>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long SlotId { get; set; }


    }
}
