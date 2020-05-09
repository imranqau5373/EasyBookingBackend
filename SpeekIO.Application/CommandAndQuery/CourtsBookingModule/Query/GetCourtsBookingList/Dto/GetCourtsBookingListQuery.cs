
using EasyBooking.Application.Common.Dto;
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto
{
    public class GetCourtsBookingListQuery : PagingQuery, IRequest<GetCourtsBookingListResponse>
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
