﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots.Dto
{
	public class GetCourtsDurationSlotsDto
	{

		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? BookingStartTime { get; set; }
		public DateTime? BookingEndTime { get; set; }
		public bool IsBooked { get; set; }
		public bool IsEmailed { get; set; }
		public long DurationId { get; set; }
		public long? CourtsId { get; set; }
		public long? UserId { get; set; }
		public long DurationStatusId { get; set; }
	}
}
