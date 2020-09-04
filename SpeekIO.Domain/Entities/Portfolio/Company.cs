using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Portfolio;
using SpeekIO.Domain.Interfaces;
using System.Collections.Generic;

namespace SpeekIO.Domain.Entities.Portfolio
{
	public class Company : BaseEntity, IEntity
    {

		public Company()
		{
			Sports = new HashSet<Sports>();
			Courts = new HashSet<Courts>();
		}
        public string Name { get; set; }
        public string Url { get; set; }
        public string SubDomainPrefix { get; set; }
		public long? PackageId { get; set; }
		public virtual Package Package { get; set; }
		public List<Profile> Profiles { get; set; } = new List<Profile>();
		public ICollection<Sports> Sports { get; set; }
		public ICollection<Courts> Courts { get; set; }

	}
}
