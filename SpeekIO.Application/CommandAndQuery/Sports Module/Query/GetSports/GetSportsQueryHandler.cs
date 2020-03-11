using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
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
namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports
{
	public class GetSportsQueryHandler : CommandHandlerBase<GetSportsQuery, GetSportsResponse>
	{

		private readonly ILogger<GetSportsQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor, 
			ILogger<GetSportsQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public override async Task<GetSportsResponse> Handle(GetSportsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var  sportsObject = await _context.Sports.Where(x => x.Id == request.SportsId).FirstOrDefaultAsync();
				if (sportsObject == null)
				{
					return new GetSportsResponse()
					{
						Successful = false,
						Message = "Sports are not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetSportsResponse>(sportsObject);
					response.Successful = true;
					response.Message = "Sports found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetSportsResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting sports. " + ex.Message
				};
			}
		}
	}
}
