using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots
{
	public class GetCourtsDurationSlotsHandler : CommandHandlerBase<GetCourtsDurationSlotsQuery, GetCourtsDurationSlotsResponse>
	{

		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCourtsDurationSlotsHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override async Task<GetCourtsDurationSlotsResponse> Handle(GetCourtsDurationSlotsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = await _context.CourtsBookings.Include(x => x.CourtsDurations).Where(x => x.DurationId == request.Id)
					.Select(x => new GetCourtsDurationSlotsDto
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description,
						CourtsId = x.CourtsId,
						BookingStartTime = x.BookingStartTime,
						BookingEndTime = x.BookingEndTime,
						IsBooked = x.IsBooked,
						IsEmailed = x.IsEmailed,
						DurationStatusId = x.CourtsDurations.DurationStatusId
					}).ToListAsync();
				//var comapanyList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCourtsDurationSlotsResponse()
				{
					Successful = true,
					Message = "Courts Durations are found successfully.",
					slotsList = result
				};
			}
			catch (Exception ex)
			{
				return new GetCourtsDurationSlotsResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Bookings. " + ex.Message
				};
			}
		}
	}
}
