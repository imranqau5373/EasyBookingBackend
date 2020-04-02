using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Common.Session
{
	public interface IUserSession
	{

		long? OrganizationUnitId { get; }
		int? TimeZoneOffset { get; }
		long? UserId { get; }
		long? CompanyId { get; }
		bool IsAdmin { get; }
	}
}
