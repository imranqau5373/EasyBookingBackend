using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetTimeSchedule.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetTimeSchedule
{
    public class GetTimeScheduleQueryHandler : CommandHandlerBase<GetTimeScheduleQuery, GetTimeScheduleResponse>
    {


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public GetTimeScheduleQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public async override Task<GetTimeScheduleResponse> Handle(GetTimeScheduleQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var timeScheduleList = await _context.DayTimeDays.Where(x => x.DayTimeScheduleId == request.Id).Select(x => new TimeScheduleResponseData { 
					Day = x.Day,
					startTime = x.StartTime.ToString("HH:mm"),
					endTime = x.EndTime.ToString("HH:mm")
				}).ToListAsync();
				if (timeScheduleList == null)
				{
					return new GetTimeScheduleResponse()
					{
						Successful = false,
						Message = "TimeSchedule is not found."
					};
				}
				else
				{
					var response = new GetTimeScheduleResponse();
					response.timeScheduleReponse = timeScheduleList.ToArray();
					response.Successful = true;
					response.Message = "TimeSchedule found successfully.";
					return response;
				}
			}
			catch (Exception ex)
			{
				return new GetTimeScheduleResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting daytime schedule. " + ex.Message
				};
			}
		}
	}
}
