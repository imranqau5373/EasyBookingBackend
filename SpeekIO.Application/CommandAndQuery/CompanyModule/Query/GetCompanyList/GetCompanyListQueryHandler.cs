
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
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList
{
    public class GetCompanyListQueryHandler : CommandHandlerBase<GetCompanyListQuery, GetCompanyListResponse>
	{
		private readonly ILogger<GetCompanyListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetCompanyListQueryHandler(
			ApplicationUserManager userManager, 
			IHttpContextAccessor httpContextAccessor, 
			ILogger<GetCompanyListQueryHandler> logger, 
			AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public override async Task<GetCompanyListResponse> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Companies
					.Select(x => new GetCompanyListDto
					{
						Id = x.Id,
						Name = x.Name,
						Url = x.Url,
						SubDomainPrefix = x.SubDomainPrefix,
						LastUpdated = x.ModifiedOn,
						SportsCount = x.Sports.Count,
						CourtsCount = x.Courts.Count
					}).ToList();

				var totalRecord = result.Count();
				//var comapanyList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCompanyListResponse()
				{
					Successful = true,
					Message = "Companies are found successfully.",
					Items = result,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetCompanyListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Companies. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
