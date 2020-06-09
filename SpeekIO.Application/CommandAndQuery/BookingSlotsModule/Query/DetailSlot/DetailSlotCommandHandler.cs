using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot.Dto;
using EasyBooking.Common.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot
{
    public class DetailSlotCommandHandler : CommandHandlerBase<DetailSlotCommand, DetailSlotReponse>
	{

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public DetailSlotCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<DetailSlotReponse> Handle(DetailSlotCommand request, CancellationToken cancellationToken)
		{

			try
			{
				return await (from booking in _context.CourtsBookings // outer sequence
							  join user in _context.Users //inner sequence 
							  on booking.UserId equals user.Id // key selector 
							  join duration in _context.CourtsDurations
							  on booking.DurationId equals duration.Id
							  where booking.Id == request.SlotId
							  select new DetailSlotReponse
							  { // result selector 
								  Successful = true,
								  Message = "Slot detail sent successfully.",
								  BookingStartTime = booking.BookingStartTime,
								  BookingEndTime = booking.BookingEndTime,
								  PinCode = booking.PinCode,
								  SlotAmount = booking.SlotAmount,
								  Name = booking.Name,
								  BookedEmail = user != null ? user.Email : "",
								  SlotIsPaid = booking.SlotIsPaid,
								  SlotDuration = duration.SlotDuration
							  }).FirstOrDefaultAsync();

			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
