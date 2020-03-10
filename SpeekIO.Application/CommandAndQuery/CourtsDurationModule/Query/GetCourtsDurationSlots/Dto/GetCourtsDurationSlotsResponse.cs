using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots.Dto
{
	public class GetCourtsDurationSlotsResponse :  CommonResponse
	{
		public List<GetCourtsDurationSlotsDto> slotsList = new List<GetCourtsDurationSlotsDto>();
	}
}
