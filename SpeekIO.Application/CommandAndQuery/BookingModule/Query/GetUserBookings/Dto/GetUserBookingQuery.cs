
using EasyBooking.Application.Common.Dto;
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings.Dto
{
    public class GetUserBookingQuery : PagingQuery, IRequest<GetUserBookingResponse>
    {
		public string Name { get; set; }
		//public int? CourtCount { get; set; }
		public DateSearchDto LastUpdated { get; set; }

		public DateSearchDto BookingDate { get; set; }
		public string CreatedBy { get; set; }
		public string SortColumn { get; set; }
		public string SortDirection { get; set; }

		public int CompanyId { get; set; }
	}
}
