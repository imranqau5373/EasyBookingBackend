﻿using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList
{
	public class GetSportsByCompanyListQueryHandler : IRequestHandler<GetSportsByCompanyListQuery, GetSportsByCompanyListResponse>
	{
		private readonly ILogger<GetSportsByCompanyListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsByCompanyListQueryHandler(ILogger<GetSportsByCompanyListQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<GetSportsByCompanyListResponse> Handle(GetSportsByCompanyListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Sports.Where(x=> x.CompanyId == request.CompanyId)
					.Select(x => new GetSportsByCompanyListDto
					{
						Id = x.Id,
						Name = x.Name
					}).ToList();

				var totalRecord = result.Count();
				return new GetSportsByCompanyListResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					SportsList = result,
				};
			}
			catch (Exception ex)
			{
				return new GetSportsByCompanyListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting categories. " + ex.Message
				};
			}
		}
	}
}