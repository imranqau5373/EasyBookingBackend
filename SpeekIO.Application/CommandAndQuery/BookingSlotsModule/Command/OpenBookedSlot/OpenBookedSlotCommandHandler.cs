using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.OpenBookedSlot.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.OpenBookedSlot
{
    public class OpenBookedSlotCommandHandler : CommandHandlerBase<OpenBookedSlotCommand, OpenBookedSlotResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public OpenBookedSlotCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<OpenBookedSlotResponse> Handle(OpenBookedSlotCommand request, CancellationToken cancellationToken)
		{

			try
			{
				var slot = await _context.CourtsBookings.Where(x => x.Id == request.SlotId).FirstOrDefaultAsync();
				if (slot != null)
				{
					slot.IsBooked = false;
					slot.IsCancelled = false;
					await _context.SaveChangesAsync(User);
				}
				return new OpenBookedSlotResponse
				{
					Successful = true,
					Message = "Slot Cancelled successfully."
				};
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
