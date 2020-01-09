using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities.Bookings
{
	public class CourtsDurations : BaseEntity, IEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }
	
		public long? CourtsId { get; set; }

		public int SlotDuration { get; set; }
		
		public DateTime? CourtStartTime { get; set; }

		public DateTime? CourtEndTime { get; set; }

		public virtual Courts Courts { get; set; }

	}
}
