using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsBySportCompany.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsBySportCompany
{
    public class GetCourtsBySportCompanyQueryHandler : IRequestHandler<GetCourtsBySportCompanyListQuery, GetCourtsBySportCompanyListResponse>
	{
		private readonly ILogger<GetCourtsBySportCompanyQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetCourtsBySportCompanyQueryHandler(ILogger<GetCourtsBySportCompanyQueryHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetCourtsBySportCompanyListResponse> Handle(GetCourtsBySportCompanyListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = _context.Courts
					.Where(c=>c.SportsId == request.SportId)
					.Select(x => new GetCourtsBySportCompanyListDto
					{
						Id = x.Id,
						Name = x.Name
					}).ToList();

				var totalRecord = result.Count();
				return new GetCourtsBySportCompanyListResponse()
				{
					Successful = true,
					Message = "courts are found successfully.",
					CourtsList = result
				};
			}
			catch (Exception ex)
			{
				return new GetCourtsBySportCompanyListResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting courts. " + ex.Message,
				};
			}
		}
	}
}
