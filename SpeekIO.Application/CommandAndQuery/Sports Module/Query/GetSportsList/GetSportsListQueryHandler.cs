using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Common.Extensions;
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
namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList
{
	public class GetSportsListQueryHandler : CommandHandlerBase<GetSportsListQuery, GetSportsListResponse>
	{
		private readonly ILogger<GetSportsListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsListQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor, 
			ILogger<GetSportsListQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}
		public override async Task<GetSportsListResponse> Handle(GetSportsListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Sports.Include(x => x.Courts)
					 //.Join(_context.Profiles, s => s.CreatedBy, p => p.UserId, (s, p) => new { sports = s, Profile = p })
					.Select(x => new GetSportsListDto
					{
						Id = x.Id,
						Name = x.Name,
						LastUpdated = x.ModifiedOn,
						CreatedBy = "Super Admin",
						CourtCount = x.Courts.Count(),
						
					}).WhereIf(!request.Name.IsNullOrEmpty(), x => x.Name.Contains(request.Name));
				switch (request.SortColumn)
				{
					case "Name":
						{
							result = request.SortDirection == "ASC" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
						}
						break;
					default:
						{
							result = request.SortDirection == "ASC" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
						}
						break;
				}
				var totalRecord = await result.CountAsync();
				var sportsList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetSportsListResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					Items = sportsList,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetSportsListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting categories. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
