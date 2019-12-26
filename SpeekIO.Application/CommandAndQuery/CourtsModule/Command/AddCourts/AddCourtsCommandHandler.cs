using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts
{
    public class AddCourtsCommandHandler : IRequestHandler<AddCourtsCommand, AddCourtsResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCourtsCommandHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AddCourtsResponse> Handle(AddCourtsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var courtsModel = _mapper.Map<Courts>(request);
				var courtsData = await _context.Courts.AddAsync(courtsModel);
				await _context.SaveChangesAsync();
				if (courtsData.Entity.Id < 1)
				{
					return new AddCourtsResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding courts."
					};
				}
				else
				{
					var courtsObject = _mapper.Map<AddCourtsResponse>(courtsData.Entity);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddCourtsResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding courts. " + ex.Message
				};
			}
		}
	}
}
