using EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles.Dto;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserList.Dto
{
	public class GetUserListResponse : CommonResponse
	{
		public List<UserListModel> UserList { get; set; }
	}

	public class UserListModel
	{
		public UserListModel()
		{
			Roles = new List<GetUserRoleModel>();
		}
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public List<GetUserRoleModel> Roles { get; set; }
		public bool IsActive { get; set; }
	}
}
