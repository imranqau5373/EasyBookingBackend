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
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsCompany
{
	public class GetSportsCompanyHandler : CommandHandlerBase<GetSportsCompanyQuery, GetSportsCompanyResponse>
	{
		private readonly ILogger<GetSportsCompanyHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetSportsCompanyHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor, 
			ILogger<GetSportsCompanyHandler> logger, AutoMapper.IMapper mapper, SpeekIOContext context) : base(userManager, httpContextAccessor)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public override async Task<GetSportsCompanyResponse> Handle(GetSportsCompanyQuery request, CancellationToken cancellationToken)
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
