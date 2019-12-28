using EasyBooking.Application.Common.Dto;
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto
{
	public class GetSportsListQuery : PagingQuery, IRequest<GetSportsListResponse>
	{

	}
}
