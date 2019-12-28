using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsCompany.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsCompany
{
	public class GetSportsCompanyHandler : IRequestHandler<GetSportsCompanyQuery, GetSportsCompanyResponse>
	{
		private readonly ILogger<GetSportsCompanyHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsCompanyHandler(ILogger<GetSportsCompanyHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetSportsCompanyResponse> Handle(GetSportsCompanyQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var result = await _context.Companies.Select(x => new SportsCompanyDto
								{
									Id = x.Id,
									Name = x.Name
								}).ToListAsync();
				return new GetSportsCompanyResponse()
				{
					Successful = true,
					Message = "Sports are found successfully.",
					CompanyList = result
				};

			}
			catch(Exception ex)
			{
				return new GetSportsCompanyResponse()
				{
					Successful = false,
					Message = "companies are not found successfully."+ex.Message
				};
			}
		}
	}
}
