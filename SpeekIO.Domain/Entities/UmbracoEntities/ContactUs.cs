using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.UmbracoEntities
{
	public class ContactUs :BaseEntity, IEntity 
	{

		public string CompanyName { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
	}
}
