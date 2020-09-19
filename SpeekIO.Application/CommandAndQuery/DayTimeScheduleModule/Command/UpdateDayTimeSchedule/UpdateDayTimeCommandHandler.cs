using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule.Dto;
using EasyBooking.Common.Session;
using EasyBooking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule
{
    public class UpdateDayTimeCommandHandler : CommandHandlerBase<UpdateDayTimeCommand, UpdateDayTimeResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public UpdateDayTimeCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<UpdateDayTimeResponse> Handle(UpdateDayTimeCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var dayTime = await _context.DayTimeSchedules.FindAsync(request.Id);
				_context.Entry(dayTime).State = EntityState.Detached;
				dayTime = _mapper.Map<DayTimeSchedule>(request);
				_context.Entry(dayTime).State = EntityState.Modified;
				await _context.SaveChangesAsync(User);
				if (dayTime.Id < 1)
				{
					return new UpdateDayTimeResponse()
					{
						Successful = false,
						Message = "Something went wrong while updating daytime schedule."
					};
				}
				return new UpdateDayTimeResponse()
				{
					Successful = true,
					Message = "daytime schedule updated successfully."
				};
			}
			catch (Exception ex)
			{
				return new UpdateDayTimeResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding courts. " + ex.Message
				};
			}
		}
	}
}
