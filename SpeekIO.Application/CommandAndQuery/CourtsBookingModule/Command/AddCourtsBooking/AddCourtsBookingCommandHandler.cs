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

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking
{
    public class AddCourtsBookingCommandHandler : IRequestHandler<AddCourtsBookingCommand, AddCourtsBookingResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCourtsBookingCommandHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AddCourtsBookingResponse> Handle(AddCourtsBookingCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var bookingModel = _mapper.Map<CourtBookings>(request);
				var bookingData = await _context.CourtsBookings.AddAsync(bookingModel);
				await _context.SaveChangesAsync();
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
