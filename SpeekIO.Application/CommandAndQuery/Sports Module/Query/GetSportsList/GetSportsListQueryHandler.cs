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

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList
{
	public class GetSportsListQueryHandler : IRequestHandler<GetSportsListQuery, GetSportsListResponse>
	{
		private readonly ILogger<GetSportsListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsListQueryHandler(ILogger<GetSportsListQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<GetSportsListResponse> Handle(GetSportsListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Sports.Include(x => x.Courts)
					.Select(x => new GetSportsListDto
					{
						Id = x.Id,
						Name = x.Name,
						LastUpdated = x.ModifiedOn,
						CourtCount = x.Courts.Count()
					}).ToList();

				var totalRecord = result.Count();
				//var sportsList = result;//await result.Page(1, 10).ToListAsync();
				//var data = result.ToListAsync();
				return new GetSportsListResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					Items = result,
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
