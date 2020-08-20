using EasyBooking.Application.CommandAndQuery.Identity.Command.AddGuestUser.Dto;
using EasyBooking.Application.CommandAndQuery.Identity.Query.GetUserRoles.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Identity.Command.AddGuestUser
{
    public class AddGuestUserCommand : IRequest<AddGuestUserResponse>
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public List<GetUserRoleModel> SelectedRoles { get; set; }
    }
}
