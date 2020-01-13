using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto
{
	public class GetSportsQuery : IRequest<GetSportsResponse>
	{
		public long SportsId { get; set; }
	}
}
