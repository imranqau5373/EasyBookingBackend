using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddTimeSchedule.Dto;
using EasyBooking.Common.Session;
using EasyBooking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddTimeSchedule
{
    public class AddTimeScheduleCommandHandler : CommandHandlerBase<AddTimeScheduleCommand, AddTimeScheduleResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public AddTimeScheduleCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<AddTimeScheduleResponse> Handle(AddTimeScheduleCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var timeModel = _mapper.Map<DayTimeDays>(request);
				await _context.DayTimeDays.AddAsync(timeModel);
				await _context.SaveChangesAsync(User);
				if (timeModel.Id < 1)
				{
					return new AddTimeScheduleResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding time schedule."
					};
				}
				else
				{
					var timeObject = new AddTimeScheduleResponse();
					timeObject.Successful = true;
					return timeObject;
				}
			}
			catch (Exception ex)
			{
				return new AddTimeScheduleResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding time. " + ex.Message
				};
			}
		}
	}
}
