﻿using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto;
using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
using MediatR;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration
{
	public class AddCourtsBookingCommandHandler : CommandHandlerBase<AddCourtsDurationCommand, AddCourtsDurationResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCourtsBookingCommandHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override async Task<AddCourtsDurationResponse> Handle(AddCourtsDurationCommand request, CancellationToken cancellationToken)
		{
			
			try
			{
				var model = _mapper.Map<CourtsDurations>(request);
				var data = await _context.CourtsDurations.AddAsync(model);
				await _context.SaveChangesAsync(User);
				
				if (data.Entity.Id < 1)
				{
					return new AddCourtsDurationResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding details."
					};
				}
				else
				{
					request.DurationId = data.Entity.Id;
					await GetSlotsDetails(request.DayTimeZoneId.Value,request);
					var courtsObject = _mapper.Map<AddCourtsDurationResponse>(data.Entity);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddCourtsDurationResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding details. " + ex.Message
				};
			}
		}
		//calcute number of slots
		public async Task calculateSlots(AddCourtsDurationCommand request,ApplicationUser User)
		{
			var startTime = request.CourtStartTime.Value.Hour;
			var endTime = request.CourtEndTime.Value.Hour;
			var totalSlots = 0;
			//chk for -tvie
			totalSlots =((endTime - startTime)*60) / request.SlotDuration;
			await addBooking(totalSlots,request,User);
		}
		//add court bookings
		public async Task addBooking(int slotsCount, AddCourtsDurationCommand request,ApplicationUser User)
		{
			AddCourtsBookingCommand data = new AddCourtsBookingCommand();
			var startTime = request.CourtStartTime;
			var slotDuration = request.SlotDuration;
			for (int i = 0; i < slotsCount; i++)
			{
				data.CourtId = request.CourtId;
				data.Name = request.Name;
				data.Description = request.Description;
				data.UserId = request.UserId;
				data.IsBooked = false;
				data.IsEmailed = false;				
				data.BookingStartTime = startTime;
				var endTime = startTime.Value.AddMinutes(slotDuration);
				data.BookingEndTime = endTime;
				
				var model = _mapper.Map<CourtBookings>(data);
				model.DurationId = request.DurationId;
				await _context.CourtsBookings.AddAsync(model);
				await _context.SaveChangesAsync(User);
				startTime = endTime;
			}
		}

		private async Task GetSlotsDetails(long dayTimeZoneId, AddCourtsDurationCommand request)
		{
			var getSlotDays = await _context.DayTimeDays.Where(x => x.DayTimeScheduleId == dayTimeZoneId).ToListAsync();
			if(getSlotDays != null)
			{
				for(int i = 0; i<getSlotDays.Count; i++)
				{
					var obj = getSlotDays[i];
					await DaySlotCalculated(obj.StartTime, obj.EndTime, request);
				}
			}

		}

		private async Task DaySlotCalculated(DateTime startTime,DateTime endTime, AddCourtsDurationCommand request)
		{
			var totalSlots = 0;
			totalSlots = ((endTime.Hour - startTime.Hour) * 60) / request.SlotDuration;
			await addBookingSlot(totalSlots, request, User,startTime);
		}

		public async Task addBookingSlot(int slotsCount, AddCourtsDurationCommand request, ApplicationUser User,DateTime startTime)
		{
			AddCourtsBookingCommand data = new AddCourtsBookingCommand();
			var slotDuration = request.SlotDuration;
			for (int i = 0; i < slotsCount; i++)
			{
				data.CourtId = request.CourtId;
				data.Name = request.Name;
				data.Description = request.Description;
				data.UserId = request.UserId;
				data.IsBooked = false;
				data.IsEmailed = false;
				data.BookingStartTime = startTime;
				var endTime = startTime.AddMinutes(slotDuration);
				data.BookingEndTime = endTime;

				var model = _mapper.Map<CourtBookings>(data);
				model.DurationId = request.DurationId;
				await _context.CourtsBookings.AddAsync(model);
				await _context.SaveChangesAsync(User);
				startTime = endTime;
			}
		}

	}
}
