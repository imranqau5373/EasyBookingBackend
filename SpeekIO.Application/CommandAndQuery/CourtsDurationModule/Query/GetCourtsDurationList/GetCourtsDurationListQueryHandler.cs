
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
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using EasyBooking.Common.Session;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList
{
	public class GetCourtsDurationListQueryHandler : CommandHandlerBase<GetCourtsDurationListQuery, GetCourtsDurationListResponse>
	{
		private readonly ILogger<GetCourtsDurationListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;
		private readonly IUserSession _userSession;
		public GetCourtsDurationListQueryHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			ILogger<GetCourtsDurationListQueryHandler> logger, IUserSession userSession,
			AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
			this._userSession = userSession;
		}

		public override async Task<GetCourtsDurationListResponse> Handle(GetCourtsDurationListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.CourtsDurations.Include(x => x.Courts)
					.Where(x => x.Courts.CompanyId == _userSession.CompanyId)
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
				var comapanyList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCourtsDurationListResponse()
				{
					Successful = true,
					Message = "Courts Durations are found successfully.",
					Items = comapanyList,
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
