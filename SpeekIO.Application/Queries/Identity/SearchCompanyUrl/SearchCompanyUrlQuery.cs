using MediatR;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.Identity.SearchCompanyUrl
{
	public class SearchCompanyUrlQuery : IRequest<SearchCompanyUrlResponse>
	{
		public string strCompanyUrl { get; set; }
	}
}
