using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList
{
	public class GetSportsListQueryHandler : IRequestHandler<GetSportsListQuery, SportsListResponse>
	{
		private readonly ILogger<GetSportsListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly ISpeekIODbContext _context;

		public GetSportsListQueryHandler(ILogger<GetSportsListQueryHandler> logger, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<SportsListResponse> Handle(GetSportsListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Sports.Include(x => x.Courts)
					.Select(x => new SportsListDto
					{
						Id = x.Id,
						Name = x.Name,
						LastUpdated = x.ModifiedOn,
						CourtCount = x.Courts.Count()
					});

				var totalRecord = result.Count();
				var sportsList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new SportsListResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					Items = sportsList,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new SportsListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting categories. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
