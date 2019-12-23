using EasyBooking.Domain.Entities;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Profile> Profiles { get; set; } = new List<Profile>();

		public ICollection<Sports> Sports { get; set; }

		public ICollection<Courts> Courts { get; set; }

	}
}
