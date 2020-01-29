using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings.Dto
{
	public class GetCompanyBookingResponse : CommonResponse
	{

		public List<GetCompanyBookingListDto> Items { get; set; }
	}
}
