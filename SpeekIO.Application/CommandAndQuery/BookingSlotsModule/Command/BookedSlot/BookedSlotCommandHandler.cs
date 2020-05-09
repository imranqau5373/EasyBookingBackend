using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot
{
    public class BookedSlotCommandHandler : CommandHandlerBase<BookedSlotCommand, BookedSlotResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public BookedSlotCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<BookedSlotResponse> Handle(BookedSlotCommand request, CancellationToken cancellationToken)
		{

			try
			{
				var slot = await _context.CourtsBookings.Where(x => x.Id == request.SlotId).FirstOrDefaultAsync();
				if (slot != null)
				{
					slot.IsBooked = false;
					slot.IsCancelled = true;
					await _context.SaveChangesAsync(User);

				}
				return new BookedSlotResponse
				{
					Successful = true,
					Message = "Slot booked successfully."
				};
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
