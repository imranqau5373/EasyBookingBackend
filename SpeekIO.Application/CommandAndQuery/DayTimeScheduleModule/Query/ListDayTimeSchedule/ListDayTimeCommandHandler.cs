using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.ListDayTimeSchedule.Dto;
using EasyBooking.Common.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.ListDayTimeSchedule
{
    public class ListDayTimeCommandHandler : CommandHandlerBase<ListDayTimeScheduleCommand, ListDayTimeScheduleResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public ListDayTimeCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<ListDayTimeScheduleResponse> Handle(ListDayTimeScheduleCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.DayTimeSchedules
					.Where(x => x.IsDeleted != true)
					.Select(x => new ListDayTimeScheduleDto
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description
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
				var courtsList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new ListDayTimeScheduleResponse()
				{
					Successful = true,
					Message = "Daytime schedule are found successfully.",
					Items = courtsList,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new ListDayTimeScheduleResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting dayTime Schedule. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
