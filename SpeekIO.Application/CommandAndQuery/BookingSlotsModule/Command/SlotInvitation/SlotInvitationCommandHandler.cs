using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.SlotInvitation.Dto;
using EasyBooking.Common.Session;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.SlotInvitation
{
    public class SlotInvitationCommandHandler : CommandHandlerBase<SlotInvitationCommand, SlotInvitationResponse>
    {
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public SlotInvitationCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override Task<SlotInvitationResponse> Handle(SlotInvitationCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		
	}
}
