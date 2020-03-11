using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList.Dto;
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
namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList
{
	public class GetSportsByCompanyListQueryHandler : CommandHandlerBase<GetSportsByCompanyListQuery, GetSportsByCompanyListResponse>
	{
		private readonly ILogger<GetSportsByCompanyListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsByCompanyListQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor, 
			ILogger<GetSportsByCompanyListQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}
		public override async Task<GetSportsByCompanyListResponse> Handle(GetSportsByCompanyListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result =await _context.Sports.Where(x=> x.CompanyId == request.CompanyId)
					.Select(x => new GetSportsByCompanyListDto
					{
						Id = x.Id,
						Name = x.Name
					}).ToListAsync();

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
