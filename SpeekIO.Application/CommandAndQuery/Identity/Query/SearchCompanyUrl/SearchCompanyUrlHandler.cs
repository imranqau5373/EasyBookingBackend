using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Identity.SearchCompanyUrl
{
	public class SearchCompanyUrlHandler : IRequestHandler<SearchCompanyUrlQuery, SearchCompanyUrlResponse>
	{

		private readonly ILogger<SearchCompanyUrlHandler> _logger;
		private readonly SpeekIOContext _context;

		public SearchCompanyUrlHandler(ILogger<SearchCompanyUrlHandler> logger, SpeekIOContext context)
		{
			this._logger = logger;
			_context = context;
		}
		public async Task<SearchCompanyUrlResponse> Handle(SearchCompanyUrlQuery request, CancellationToken cancellationToken)
		{
			var company = await GetCompany(request.strCompanyUrl);
			if(company == null)
			{
				return new SearchCompanyUrlResponse()
				{
					Successful = true
				};
			}
			else
			{
				return new SearchCompanyUrlResponse()
				{
					Successful = false
				};
			}
		}

		private async Task<Company> GetCompany(string strCompanyUrl)
		{
			var company = await _context.Companies.Where(x => x.Url == strCompanyUrl).FirstOrDefaultAsync();
			return company;
		}
	}
}
