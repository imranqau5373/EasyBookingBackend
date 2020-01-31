using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings.Dto
{
	public class GetCompanyBookingQuery : IRequest<GetCompanyBookingResponse>
	{

		public DateTime? todayDate { get; set; }

		public long? bookingId { get; set; }

	}
}
