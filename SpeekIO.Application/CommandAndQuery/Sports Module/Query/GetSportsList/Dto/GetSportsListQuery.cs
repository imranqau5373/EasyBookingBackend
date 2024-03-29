﻿using EasyBooking.Application.Common.Dto;
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto
{
	public class GetSportsListQuery : PagingQuery, IRequest<GetSportsListResponse>
	{
		public string Name { get; set; }
		public int? CourtCount { get; set; }
		public DateSearchDto LastUpdated { get; set; }
		public string CreatedBy { get; set; }
		public string SortColumn { get; set; }
		public string SortDirection { get; set; }
	}
}
