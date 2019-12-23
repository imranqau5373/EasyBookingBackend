using AutoMapper;
using EasyBooking.Domain.Entities;
using MediatR;
using SpeekIO.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto
{
	public class AddSportsCommandHandler : IRequestHandler<AddSportsCommand, AddSportsResponse>
	{


		private readonly ISpeekIODbContext _context;
		private readonly IMapper _mapper;
		public AddSportsCommandHandler(
			ISpeekIODbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<AddSportsResponse> Handle(AddSportsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var sportsModel = _mapper.Map<Sports>(request);
				var sportsData = await _context.Sports.AddAsync(sportsModel);
				await _context.SaveChangesAsync();
				if (sportsData.Entity.Id < 1)
				{
					return new AddSportsResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding sports."
					};
				}
				else
				{
					var sportsObject = _mapper.Map<AddSportsResponse>(sportsData.Entity);
					sportsObject.Successful = true;
					return sportsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddSportsResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding category. " + ex.Message
				};
			}
		}
	}
}
