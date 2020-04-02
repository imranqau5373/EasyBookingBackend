using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Common.Session
{
	public class UserSession : IUserSession
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserSession(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public long? OrganizationUnitId
		{
			get
			{
				var organizationUnitId = _httpContextAccessor.HttpContext?.Request.Headers["OrganizationUnitId"];
				return organizationUnitId?.Count > 0 ? Convert.ToInt64(organizationUnitId) : (long?)null;
			}
		}

		public int? TimeZoneOffset
		{
			get
			{
				var timeZone = _httpContextAccessor.HttpContext?.Request.Headers["TimeZoneOffset"];
				return timeZone?.Count > 0 ? Convert.ToInt32(timeZone) : (int?)null;
			}
		}

		public long? UserId
		{
			get
			{
				var userId = _httpContextAccessor.HttpContext?.Request.Headers["UserId"];
				return userId?.Count > 0 ? Convert.ToInt64(userId) : (long?)null;
			}
		}

		public long? CompanyId
		{
			get
			{
				var companyId = _httpContextAccessor.HttpContext?.Request.Headers["CompanyId"];
				return companyId?.Count > 0 ? Convert.ToInt32(companyId) : (int?)null;
			}
		}

		public bool IsAdmin
		{
			get
			{
				var isAdmin = _httpContextAccessor.HttpContext?.Request.Headers["IsAdmin"];
				return Convert.ToBoolean(isAdmin);
			}
		}
	}
}
