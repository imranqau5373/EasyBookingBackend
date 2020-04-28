
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Common.Extensions;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList
{
	public class GetCourtsBookingListQueryHandler : IRequestHandler<GetCourtsBookingListQuery, GetCourtsBookingListResponse>
	{
		private readonly ILogger<GetCourtsBookingListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetCourtsBookingListQueryHandler(
			ILogger<GetCourtsBookingListQueryHandler> logger, 
			AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetCourtsBookingListResponse> Handle(GetCourtsBookingListQuery request, CancellationToken cancellationToken)
		{
			try
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
						IsEmailed = x.IsEmailed
					}).WhereIf(!request.Name.IsNullOrEmpty(), x => x.Name.Contains(request.Name));
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
				request.PageNumber = 1;
				request.PageSize = 1000;
				var bookingList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCourtsBookingListResponse()
				{
					Successful = true,
					Message = "Bookings are found successfully.",
					Items = bookingList,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetCourtsBookingListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Bookings. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
