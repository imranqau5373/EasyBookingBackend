using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities.Bookings
{
	public class DurationStatus : BaseEntity, IEntity
	{
		public string Name { get; set; }
	}
}
