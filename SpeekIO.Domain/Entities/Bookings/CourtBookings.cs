using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyBooking.Domain.Entities.Bookings
{
	public class CourtBookings : BaseEntity, IEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? BookingStartTime { get; set; }
		public DateTime? BookingEndTime { get; set; }
		public bool IsBooked { get; set; }
		public bool IsEmailed { get; set; }
		public bool IsCancelled { get; set; }


		[ForeignKey("DurationId")]
		public long DurationId { get; set; }

		public virtual CourtsDurations CourtsDurations { get; set; }

		public long? CourtsId { get; set; }
		public virtual Courts Courts { get; set; }


		public long? UserId { get; set; }
		public virtual Profile Profile { get; set; }


	}
}
