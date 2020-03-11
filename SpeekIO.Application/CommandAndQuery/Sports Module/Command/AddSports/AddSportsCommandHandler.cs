using AutoMapper;
using EasyBooking.Domain.Entities;
using MediatR;
using SpeekIO.Application.Interfaces;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto
{
	public class AddSportsCommandHandler : CommandHandlerBase<AddSportsCommand, AddSportsResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddSportsCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}
		public override async Task<AddSportsResponse> Handle(AddSportsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var sportsModel = _mapper.Map<Sports>(request);
				var sportsData = await _context.Sports.AddAsync(sportsModel);
				await _context.SaveChangesAsync(User);
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
