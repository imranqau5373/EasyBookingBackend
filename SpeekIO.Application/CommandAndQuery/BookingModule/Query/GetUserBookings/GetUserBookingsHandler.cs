using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Common.Extensions;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings
{
    public class GetUserBookingsHandler : CommandHandlerBase<GetUserBookingQuery, GetUserBookingResponse>
    {
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetUserBookingsHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override async Task<GetUserBookingResponse> Handle(GetUserBookingQuery request, CancellationToken cancellationToken)
		{
			var result = _context.CourtsBookings
					.Select(x => new GetCourtsBookingListDto
					{
						Id = x.Id,
						Name = x.Name,
						CourtName = x.Courts.Name,
						CourtId = x.CourtsId,
						UserId = x.UserId,
						UserName = "",
						Description = x.Description,
						BookingStartTime = x.BookingStartTime,
						BookingEndTime = x.BookingEndTime,
						IsBooked = x.IsBooked,
						IsEmailed = x.IsEmailed,
						PinCode = x.PinCode
					}).Where(x => x.UserId == User.Id);
					//.WhereIf(request.BookingDate != null, x => (x.BookingStartTime != null && request.BookingDate.Date.Date > x.BookingStartTime.Value.Date));
			switch (request.SortColumn)
			{
				case "Name":
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
					}
					break;
				default:
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
					}
					break;
			}
			var totalRecord = await result.CountAsync();
			var bookingList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
			return new GetUserBookingResponse()
			{
				Successful = true,
				Message = "Bookings are found successfully.",
				Items = bookingList,
				TotalCount = totalRecord,
			};
		}
	}
}
