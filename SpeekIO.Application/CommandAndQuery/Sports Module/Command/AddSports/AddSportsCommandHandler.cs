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
using EasyBooking.Common.Session;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto
{
	public class AddSportsCommandHandler : CommandHandlerBase<AddSportsCommand, AddSportsResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		public AddSportsCommandHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper, IUserSession userSession) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}
		public override async Task<AddSportsResponse> Handle(AddSportsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var sportsModel = _mapper.Map<Sports>(request);
				sportsModel.CompanyId = _userSession.CompanyId;
				var sportsData = await _context.Sports.AddAsync(sportsModel);
				await _context.SaveChangesAsync(User);
				if (sportsData.Entity.Id < 1)
				{
					return new AddSportsResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding category."
					};
				}
				else
				{
					var sportsObject = _mapper.Map<AddSportsResponse>(sportsData.Entity);
					sportsObject.Successful = true;
					sportsObject.Message = "Category added successfully.";
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
