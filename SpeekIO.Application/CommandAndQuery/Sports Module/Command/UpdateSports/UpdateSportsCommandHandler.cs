using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyBooking.Common.Session;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports
{
	public class UpdateSportsCommandHandler : CommandHandlerBase<UpdateSportsCommand, UpdateSportsResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IUserSession _userSession;
		public UpdateSportsCommandHandler(
			SpeekIOContext context, IMapper mapper, IApplicationConfiguration applicationConfiguration,
			ApplicationUserManager userManager, IUserSession userSession,
			IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
		}
		public override async Task<UpdateSportsResponse> Handle(UpdateSportsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var sports = await _context.Sports.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				_context.Entry(sports).State = EntityState.Detached;
				sports = _mapper.Map<Sports>(request);
				sports.CompanyId = _userSession.CompanyId;
				_context.Entry(sports).State = EntityState.Modified;
				await _context.SaveChangesAsync(User);
				if (sports.Id < 1)
				{
					return new UpdateSportsResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding sports."
					};
				}
				return new UpdateSportsResponse()
				{
					Successful = true,
					Message = "sports updated successfully."
				};
			}
			catch (Exception ex)
			{
				return new UpdateSportsResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding category. " + ex.Message
				};
			}
		}
	}
}
