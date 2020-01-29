using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking
{
	public class GetCourtsBookingQueryHandler : IRequestHandler<GetCourtsBookingQuery, GetCourtsBookingResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCourtsBookingQueryHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetCourtsBookingResponse> Handle(GetCourtsBookingQuery request, CancellationToken cancellationToken)
		{
			try
			{
				//Need to add that check with company ID as well. just get list of those booking related to the companyId
				var bookingObject = await _context.CourtsBookings.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if (bookingObject == null)
				{
					return new GetCourtsBookingResponse()
					{
						Successful = false,
						Message = "Booking is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetCourtsBookingResponse>(bookingObject);
					response.Successful = true;
					response.Message = "Booking found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetCourtsBookingResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting booking. " + ex.Message
				};
			}
		}
	}
}
