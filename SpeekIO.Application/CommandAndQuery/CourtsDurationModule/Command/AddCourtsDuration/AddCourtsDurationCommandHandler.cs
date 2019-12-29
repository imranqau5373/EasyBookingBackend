using AutoMapper;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration
{
	public class AddCourtsBookingCommandHandler : IRequestHandler<AddCourtsDurationCommand, AddCourtsDurationResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCourtsBookingCommandHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AddCourtsDurationResponse> Handle(AddCourtsDurationCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var model = _mapper.Map<CourtsDurations>(request);
				var data = await _context.CourtsDurations.AddAsync(model);
				await _context.SaveChangesAsync();
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
	}
}
