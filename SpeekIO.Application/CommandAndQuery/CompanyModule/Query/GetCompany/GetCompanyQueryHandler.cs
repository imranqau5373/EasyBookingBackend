using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany
{
    public class GetCompanyQueryHandler : CommandHandlerBase<GetCompanyQuery, GetCompanyResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCompanyQueryHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override async Task<GetCompanyResponse> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var companyObject = await _context.Companies
					.Where(x => x.Id == request.Id)
					//.Include(s => s.Sports)
					//.Include(c=>c.Courts)
					.FirstOrDefaultAsync();

				if (companyObject == null)
				{
					return new GetCompanyResponse()
					{
						Successful = false,
						Message = "Company is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetCompanyResponse>(companyObject);
					response.Successful = true;
					response.Message = "Company found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetCompanyResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Company. " + ex.Message
				};
			}
		}
	}
}
