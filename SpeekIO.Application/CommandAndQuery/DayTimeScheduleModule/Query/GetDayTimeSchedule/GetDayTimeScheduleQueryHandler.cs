using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule
{
    public class GetDayTimeScheduleQueryHandler : CommandHandlerBase<GetDayTimeScheduleQuery, GetDayTimeScheduleReponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public GetDayTimeScheduleQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<GetDayTimeScheduleReponse> Handle(GetDayTimeScheduleQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var daytimeSchedule = await _context.DayTimeSchedules.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if (daytimeSchedule == null)
				{
					return new GetDayTimeScheduleReponse()
					{
						Successful = false,
						Message = "DayTimeZone is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetDayTimeScheduleReponse>(daytimeSchedule);
					response.Successful = true;
					response.Message = "DayTimeZone found successfully.";
					return response;
				}
			}
			catch(Exception ex)
			{
				return new GetDayTimeScheduleReponse()
				{
					Successful = false,
					Message = "Something went wrong while getting daytime schedule. " + ex.Message
				};
			}
		}
	}
}
