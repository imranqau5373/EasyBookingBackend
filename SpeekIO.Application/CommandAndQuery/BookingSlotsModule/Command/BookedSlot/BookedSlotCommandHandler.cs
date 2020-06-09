using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot.Dto;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot.Dto;
using EasyBooking.Common.Session;
using EasyBooking.Domain.Entities.Bookings;
using EasyBooking.Domain.Models.Email.Booking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
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
		private readonly IEmailService _emailService;
		private readonly IMediator _mediator;
		private readonly IApplicationConfiguration _applicationConfiguration;
		public BookedSlotCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
				IApplicationConfiguration applicationConfiguration,
					 IEmailService emailService,
					 IMediator mediator,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_applicationConfiguration = applicationConfiguration;
			_mapper = mapper;
			_userSession = userSession;
			this._emailService = emailService;
			this._mediator = mediator;
		}

		public override async Task<BookedSlotResponse> Handle(BookedSlotCommand request, CancellationToken cancellationToken)
		{

			try
			{
				var slot = await _context.CourtsBookings.Where(x => x.Id == request.SlotId).FirstOrDefaultAsync();
				if (slot != null)
				{
					slot.IsBooked = true;
					slot.IsCancelled = false;
					slot.UserId = User.Id;
					slot.PinCode = GetFourDigitNumber();
					await _context.SaveChangesAsync(User);
				}
				var slotDetailCommand = new DetailSlotCommand();
				slotDetailCommand.SlotId = request.SlotId;
				var slotDetailResponse = await _mediator.Send(slotDetailCommand);
				var slotDetail = new BookingDetailEmail
				{
					Name = slotDetailResponse.Name,
					PinCode = slotDetailResponse.PinCode,
					BookedEmail = slotDetailResponse.BookedEmail,
					BookingStartTime = slotDetailResponse.BookingStartTime,
					BookingEndTime = slotDetailResponse.BookingEndTime,
					CompanyName = await _context.CourtsBookings.Include(x => x.Courts).ThenInclude(x => x.Company).Where(x => x.Courts.CompanyId == _userSession.CompanyId).Select(x => x.Courts.Company.Name).FirstOrDefaultAsync()
				};
				await SendBookingEmail(slotDetail);
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

		private long? GetFourDigitNumber()
		{
			Random generator = new Random();
			return generator.Next(1, 10000);
		}

		private async Task SendBookingEmail(BookingDetailEmail bookingDetails)
		{
			IRecipient recipient = new Recipient("", bookingDetails.BookedEmail);
			IEmailModel emailModel = new BookingConfirmationEmailModel(bookingDetails, recipient);
			emailModel.TemplateName = "BookingConfirmation";
			await _emailService.SendEmailAsync(emailModel);
		}
	}
}
