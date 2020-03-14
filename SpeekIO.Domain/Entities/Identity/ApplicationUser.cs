using EasyBooking.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>, IEntity
    {

		public ApplicationUser()
		{
			UserRoles = new HashSet<ApplicationUserRole>();
		}
		public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
	}
}
