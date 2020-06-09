using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.SlotInvitation.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.SlotInvitation
{
    public class SlotInvitationCommand : IRequest<SlotInvitationResponse>
    {

        public long SlotId { get; set; }

        public string InvitationEmail { get; set; }
    }
}
