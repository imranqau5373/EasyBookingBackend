using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities.Identity
{
	public class ApplicationRoleClaim : IdentityRoleClaim<long>
	{

		public virtual UserRole Role { get; set; }
	}
}
