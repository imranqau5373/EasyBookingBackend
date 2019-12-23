using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities
{
	public class Courts : BaseEntity, IEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CompanyId { get; set; }

		public long? SportsId { get; set; }

		public virtual Company Company { get; set; }

		public virtual Sports Sports { get; set; }


	}
}
