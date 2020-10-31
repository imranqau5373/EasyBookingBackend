using AutoMapper;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddDayTimeSchedule.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddDayTimeSchedule
{
    public class AddDayTimeCommandHandler : CommandHandlerBase<AddDayTimeCommand, AddDayTimeResponse>
    {

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public AddDayTimeCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			IUserSession userSession,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}

		public override async Task<AddDayTimeResponse> Handle(AddDayTimeCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var dayTimeModel = _mapper.Map<DayTimeSchedule>(request);
				dayTimeModel.CompanyId = _userSession.CompanyId;
				await _context.DayTimeSchedules.AddAsync(dayTimeModel);
				await _context.SaveChangesAsync(User);
				if (dayTimeModel.Id < 1)
				{
					return new AddDayTimeResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding daytime schedule."
					};
				}
				else
				{
					var courtsObject = _mapper.Map<AddDayTimeResponse>(dayTimeModel);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddDayTimeResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding courts. " + ex.Message
				};
			}
		}
	}
}
