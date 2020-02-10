using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings.Dto
{
	public class GetCompanyBookingListDto
	{

		public long? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CourtName { get; set; }
		public string UserName { get; set; }
		public string Style { get; set; }
		public long? CourtId { get; set; }
		public long? UserId { get; set; }
		public string BookingStartTime { get; set; }
		public string BookingEndTime { get; set; }
		public bool IsBooked { get; set; }
		public bool IsEmailed { get; set; }
	}
}
