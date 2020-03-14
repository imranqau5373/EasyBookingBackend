using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles.Dto
{
	public class GetUserRolesResponse : CommonResponse
	{
		public List<GetUserRoleModel> UserRolesList { get; set; }
	}

	public class GetUserRoleModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
