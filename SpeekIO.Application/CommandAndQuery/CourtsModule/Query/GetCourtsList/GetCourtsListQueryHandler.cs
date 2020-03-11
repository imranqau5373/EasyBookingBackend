using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto;
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
namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList
{
    public class GetCourtsListQueryHandler : CommandHandlerBase<GetCourtsListQuery, GetCourtsListResponse>
	{
		private readonly ILogger<GetCourtsListQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetCourtsListQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			ILogger<GetCourtsListQueryHandler> logger,
			AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public override async Task<GetCourtsListResponse> Handle(GetCourtsListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Courts
					.Select(x => new GetCourtsListDto
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description,
						SportsId = x.SportsId,
						SportsName = x.Sports.Name,
						LastUpdated = x.ModifiedOn
					}).ToList();

				var totalRecord = result.Count();
				//var courtsList = await result.Page(request.PageNumber, request.PageSize).ToListAsync();
				return new GetCourtsListResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					Items = result,
					TotalCount = totalRecord,
				};
			}
			catch (Exception ex)
			{
				return new GetCourtsListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting categories. " + ex.Message,
					TotalCount = 0
				};
			}
		}
	}
}
