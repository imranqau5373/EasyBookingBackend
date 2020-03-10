using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots.Dto
{
	public class GetCourtsDurationSlotsQuery : IRequest<GetCourtsDurationSlotsResponse>
	{
		public long Id { get; set; }
	}
}
