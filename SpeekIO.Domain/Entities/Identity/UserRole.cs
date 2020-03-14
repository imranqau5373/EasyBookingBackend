using EasyBooking.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class UserRole : IdentityRole<long>, IEntity
    {
		public UserRole()
		{
			RoleClaims = new HashSet<ApplicationRoleClaim>();
			ApplicationUserRoles = new HashSet<ApplicationUserRole>();
		}
		public bool IsPublic { get; set; }
		public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
		public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
	}
}
