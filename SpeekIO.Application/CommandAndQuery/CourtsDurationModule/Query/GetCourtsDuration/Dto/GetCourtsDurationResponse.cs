using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto
{
    public class GetCourtsDurationResponse : CommonResponse
    {
        public long? Id { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CourtId { get; set; }
		public long? CompanyId { get; set; }
		public long DurationStatusId { get; set; }

		public DateTime? CourtStartTime { get; set; }

		public DateTime? CourtEndTime { get; set; }
		public DateTime? CourtDate { get; set; }
		public int SlotDuration { get; set; }
	}
}
