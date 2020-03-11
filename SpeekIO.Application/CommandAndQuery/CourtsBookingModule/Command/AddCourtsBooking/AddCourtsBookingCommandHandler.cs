using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto;
using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
using MediatR;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking
{
    public class AddCourtsBookingCommandHandler : CommandHandlerBase<AddCourtsBookingCommand, AddCourtsBookingResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCourtsBookingCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override async Task<AddCourtsBookingResponse> Handle(AddCourtsBookingCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var bookingModel = _mapper.Map<CourtBookings>(request);
				var bookingData = await _context.CourtsBookings.AddAsync(bookingModel);
				await _context.SaveChangesAsync(User);
				if (bookingData.Entity.Id < 1)
				{
					return new AddCourtsBookingResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding booking."
					};
				}
				else
				{
					var courtsObject = _mapper.Map<AddCourtsBookingResponse>(bookingData.Entity);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddCourtsBookingResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding booking. " + ex.Message
				};
			}
		}
	}
}
