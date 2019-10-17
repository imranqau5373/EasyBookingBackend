using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.UmbracoEntities
{
	public class SubscribeEmail : BaseEntity, IEntity
	{
		public string EmailAddress { get; set; }

		public bool isSubscribed { get; set; }


	}
}
