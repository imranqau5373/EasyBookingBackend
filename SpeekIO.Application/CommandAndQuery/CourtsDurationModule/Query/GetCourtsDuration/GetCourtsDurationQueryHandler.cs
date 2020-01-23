﻿using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration
{
	public class GetCourtsDurationQueryHandler : IRequestHandler<GetCourtsDurationQuery, GetCourtsDurationResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCourtsDurationQueryHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetCourtsDurationResponse> Handle(GetCourtsDurationQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var durationObject = await _context.CourtsDurations
					.Where(x => x.Id == request.Id)
					.Select(x => new GetCourtsDurationResponse
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description,
						CourtId = x.CourtsId,
						CourtStartTime = x.CourtStartTime,
						CourtEndTime = x.CourtEndTime,
						SlotDuration = x.SlotDuration,
						SportId = x.Courts.SportsId
					})
					.FirstOrDefaultAsync();
				if (durationObject == null)
				{
					return new GetCourtsDurationResponse()
					{
						Successful = false,
						Message = "Court duration is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetCourtsDurationResponse>(durationObject);
					response.Successful = true;
					response.Message = "Court Duration found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetCourtsDurationResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting court duration. " + ex.Message
				};
			}
		}
	}
}
