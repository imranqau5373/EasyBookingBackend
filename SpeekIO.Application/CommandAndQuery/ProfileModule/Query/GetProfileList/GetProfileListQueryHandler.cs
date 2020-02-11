
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Common.Extensions;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList
{
    public class GetProfileListQueryHandler : IRequestHandler<GetProfileListQuery, GetProfileListResponse>
	{
		private readonly ILogger<GetProfileListQuery> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetProfileListQueryHandler(ILogger<GetProfileListQuery> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetProfileListResponse> Handle(GetProfileListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Companies
					.Select(x => new GetProfileListDto
					{
						Id = x.Id,
						Name = x.Name,
						LastUpdated = x.ModifiedOn
					}).ToList();

				var totalRecord = result.Count();
				//var comapanyList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetProfileListResponse()
				{
					Successful = true,
					Message = "Companies are found successfully.",
					Items = result,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetProfileListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Companies. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
