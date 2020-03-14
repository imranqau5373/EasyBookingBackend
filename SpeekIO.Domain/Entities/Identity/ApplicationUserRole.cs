using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Entities.Identity
{
	public class ApplicationUserRole : IdentityUserRole<long>
	{
		public DateTime CreatedOn { get; set; }
		public long CreatedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public long? ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ApplicationUser User { get; set; }
		public virtual UserRole Role { get; set; }
	}
}
