using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles
{
	public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, GetUserRolesResponse>
	{
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetUserRolesHandler(
			SpeekIOContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<GetUserRolesResponse> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
		{
			var roles = await _context.Roles.Select(x => new GetUserRoleModel
			{
				Id = x.Id,
				Name = x.Name
			}).ToListAsync();
			return new GetUserRolesResponse()
			{
				Successful = true,
				UserRolesList = roles
			};
		}
	}
}
