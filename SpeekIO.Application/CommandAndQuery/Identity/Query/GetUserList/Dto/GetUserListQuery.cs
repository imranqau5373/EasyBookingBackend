using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserList.Dto
{
	public class GetUserListQuery : PagingQuery, IRequest<GetUserListResponse>
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Cell { get; set; }
		public UserAccountStatus[] StatusIds { get; set; }
		public string[] RoleIds { get; set; }
		public string SortColumn { get; set; }
		public string SortDirection { get; set; }
	}

	public enum UserAccountStatus
	{
		Active = 1,
		InActive = 2
	}
}
