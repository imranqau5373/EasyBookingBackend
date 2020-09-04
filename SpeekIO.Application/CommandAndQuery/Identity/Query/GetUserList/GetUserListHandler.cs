using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserList.Dto;
using EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Common.Extensions;
using SpeekIO.Presistence.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserList
{
	public class GetUserListHandler : IRequestHandler<GetUserListQuery, GetUserListResponse>
	{
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		
		public GetUserListHandler(
			
			SpeekIOContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
	
		}
		public async Task<GetUserListResponse> Handle(GetUserListQuery request, CancellationToken cancellationToken)
		{
			var result = _context.Profiles
				.Include(t => t.Company)
				.Include(t => t.User)
				.GroupJoin(_context.ApplicationUserRole.Where(t => !t.IsDeleted), p => p.UserId, ur => ur.UserId,
				(profile, userRoleMapping) => new { profile, userRoleMapping })
				 .WhereIf(!request.Name.IsNullOrEmpty(), x => x.profile.FirstName.Contains(request.Name) || x.profile.LastName.Contains(request.Name))
				 .WhereIf(!request.Email.IsNullOrEmpty(), x => x.profile.Email.Contains(request.Email))
				 .WhereIf(!request.Cell.IsNullOrEmpty(), x => x.profile.Phone.Contains(request.Cell))
				 .WhereIf(request.StatusIds != null && request.StatusIds.Length == 1 && request.StatusIds[0] == UserAccountStatus.Active, x => x.profile.User.EmailConfirmed)
				 .WhereIf(request.StatusIds != null && request.StatusIds.Length == 1 && request.StatusIds[0] == UserAccountStatus.InActive, x => !x.profile.User.EmailConfirmed);
			//.Join(_context.UserRole, ur=>ur.userRoleMapping.)
			//.Where(t => t.profile.CompanyId == _userSession.CompanyId);
			switch (request.SortColumn)
			{
				case "Name":
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.profile.FirstName) : result.OrderByDescending(x => x.profile.FirstName);
					}
					break;
				case "Email":
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.profile.Email) : result.OrderByDescending(x => x.profile.Email);
					}
					break;
				case "Cell":
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.profile.Phone) : result.OrderByDescending(x => x.profile.Phone);
					}
					break;
				case "Status":
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.profile.User.EmailConfirmed) : result.OrderByDescending(x => x.profile.User.EmailConfirmed);
					}
					break;
				default:
					{
						result = request.SortDirection == "ASC" ? result.OrderBy(x => x.profile.CreatedOn) : result.OrderByDescending(x => x.profile.CreatedOn);
					}
					break;
			}
			var totalRecord = await result.CountAsync();
			var data = await result.Page(request.PageNumber, request.PageSize).ToListAsync();

			var profiles = data.Select(t => new UserListModel()
			{
				UserId = t.profile.UserId.Value,
				FirstName = t.profile.FirstName,
				LastName = t.profile.LastName,
				Email = t.profile.Email,
				Phone = t.profile.Phone,
				Roles = _context.UserRole
						.Where(x => t.userRoleMapping.Select(y => y.RoleId).Contains(x.Id))
						.Select(z => new GetUserRoleModel
						{
							Id = z.Id,
							Name = z.Name
						}).ToList(),
				IsActive = t.profile.User.EmailConfirmed
			})
			.ToList();

			return new GetUserListResponse()
			{
				TotalCount = totalRecord,
				UserList = profiles,
				Successful = true
			};
		}
	}
}
