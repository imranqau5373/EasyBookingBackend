using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateTimeSchedule.Dto;
using EasyBooking.Common.Session;
using EasyBooking.Domain.Entities;
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

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateTimeSchedule
{
    public class UpdateTimeScheduleCommandHandler : CommandHandlerBase<UpdateTimeScheduleCommand, UpdateTimeScheduleResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public UpdateTimeScheduleCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public async override Task<UpdateTimeScheduleResponse> Handle(UpdateTimeScheduleCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var timeData = await _context.DayTimeDays.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if(timeData != null)
				{
					timeData.StartTime = request.StartTime;
					timeData.EndTime = request.EndTime;
					await _context.SaveChangesAsync(User);
					return new UpdateTimeScheduleResponse()
					{
						Successful = true,
						Message = "Time schedule update successfully."
					};
				}
				else
				{
					return new UpdateTimeScheduleResponse()
					{
						Successful = false,
						Message = "Not able to find time schedule."
					};
				}
			}
			catch (Exception ex)
			{
				return new UpdateTimeScheduleResponse()
				{
					Successful = false,
					Message = "Something went wrong while updating time schedule. " + ex.Message
				};
			}
		}
	}
}
