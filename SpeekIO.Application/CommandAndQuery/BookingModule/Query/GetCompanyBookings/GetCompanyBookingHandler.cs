using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings.Dto;
using MediatR;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings
{
	public class GetCompanyBookingHandler : IRequestHandler<GetCompanyBookingQuery, GetCompanyBookingResponse>
	{

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCompanyBookingHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetCompanyBookingResponse> Handle(GetCompanyBookingQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.CourtsBookings
					.Select(x => new GetCompanyBookingListDto
					{
						Id = x.Id,
						Name = x.Name,
						CourtName = x.Courts.Name,
						CourtId = x.CourtsId,
						UserId = x.UserId,
						UserName = "",
						Style = "#EA157A",
						Description = x.Description,
						BookingStartTime = "2020-02-10 10:00",
						BookingEndTime = "2020-20-10 11:00",
						IsBooked = x.IsBooked,
						IsEmailed = x.IsEmailed
					}).ToList();
				return new GetCompanyBookingResponse()
				{
					Successful = true,
					Message = "Bookings are found successfully.",
					Items = result,

				};
			}
			catch (Exception ex)
			{
				return new GetCompanyBookingResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Bookings. " + ex.Message
				};
			}
		}
	}
}
