using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules.Dto;
using EasyBooking.Common.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules
{
    public class DayTimeSchedulesQueryHandler : CommandHandlerBase<DayTimeSchedulesQuery, DayTimeSchedulesResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public DayTimeSchedulesQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public async override Task<DayTimeSchedulesResponse> Handle(DayTimeSchedulesQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var dayTimeZonesList = await _context.DayTimeSchedules.Where(x => x.IsDeleted != true && x.CompanyId == _userSession.CompanyId)
						.Select(x => new DayTimeSchedulesDto
						{
							Id = x.Id,
							Name = x.Name,
							Description = x.Description
						
						}).ToListAsync();
				if (dayTimeZonesList == null)
				{
					return new DayTimeSchedulesResponse()
					{
						Successful = false,
						Message = "DayTimeZone is not found."
					};
				}
				else
				{
					var response = new DayTimeSchedulesResponse();
					response.DayTimeZonesList = dayTimeZonesList;
					response.Successful = true;
					response.Message = "DayTimeZone found successfully.";
					return response;
				}
			}
			catch (Exception ex)
			{
				return new DayTimeSchedulesResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting daytime schedule. " + ex.Message
				};
			}
		}
	}
}
