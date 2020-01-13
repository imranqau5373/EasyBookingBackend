﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationList.Dto
{
    public class GetCourtsDurationListDto
    {
        public long? Id { get; set; }
		public string Name { get; set; }
		public string CourtName { get; set; }
		public string CompanyName { get; set; }
		public string Description { get; set; }

		public long? CourtId { get; set; }

		public DateTime? CourtStartTime { get; set; }

		public DateTime? CourtEndTime { get; set; }

		public int SlotDuration { get; set; }
	}
}
