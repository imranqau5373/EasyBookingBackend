using EasyBooking.Domain.Interfaces.Entity;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities
{
	public class Sports : BaseEntity, IEntity
	{
		public Sports()
		{
			Courts = new HashSet<Courts>();
		}
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CompanyId { get; set; }
		public virtual Company Company { get; set; }
		public ICollection<Courts> Courts { get; set; }
	}
}
