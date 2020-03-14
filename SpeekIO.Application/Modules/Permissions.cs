using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.Modules
{
	public static class Permissions
	{
		public static class AdminDashboard
		{
			public const string View = "Permissions.AdminDashboard.View";
		}

		public static class SuperAdminDashboard
		{
			public const string View = "Permissions.SuperAdminDashboard.View";
		}
		public static class BookingUserDashboard
		{
			public const string View = "Permissions.BookingUserDashboard.View";
		}
		public static class SportsManager
		{
			public const string View = "Permissions.SportsManager.View";
		}
		public static class CourtsManager
		{
			public const string View = "Permissions.CourtsManager.View";
		}
		public static class CourtsDurationManager
		{
			public const string View = "Permissions.CourtsDurationManager.View";
		}
		public static class CourtsBookingManager
		{
			public const string View = "Permissions.CourtsBookingManager.View";
		}
		public static class AdminUsers
		{
			public const string View = "Permissions.AdminUsers.View";
		}

		public static class SuperAdminUsers
		{
			public const string View = "Permissions.SuperAdminUsers.View";
		}
		public static class Users
		{
			public const string View = "Permissions.Users.View";
		}
	}
}
