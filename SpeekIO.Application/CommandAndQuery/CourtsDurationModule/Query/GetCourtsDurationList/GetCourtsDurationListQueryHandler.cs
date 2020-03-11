
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationList.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList
{
	public class GetCourtsDurationListQueryHandler : IRequestHandler<GetCourtsDurationListQuery, GetCourtsDurationListResponse>
	{
		private readonly ILogger<GetCourtsDurationListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetCourtsDurationListQueryHandler(ILogger<GetCourtsDurationListQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetCourtsDurationListResponse> Handle(GetCourtsDurationListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.CourtsDurations
					.Select(x => new GetCourtsDurationListDto
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description,
						CourtId = x.CourtsId,
						CourtName = x.Courts.Name,
						CompanyName = x.Courts.Company.Name,
						CourtStartTime = x.CourtStartTime,
						CourtEndTime = x.CourtEndTime,
						SlotDuration = x.SlotDuration,
						SportId = x.Courts.SportsId,
						DurationStatusId = x.DurationStatusId
					}).ToList();

				var totalRecord = result.Count();
				//var comapanyList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCourtsDurationListResponse()
				{
					Successful = true,
					Message = "Courts Durations are found successfully.",
					Items = result,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetCourtsDurationListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Bookings. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
