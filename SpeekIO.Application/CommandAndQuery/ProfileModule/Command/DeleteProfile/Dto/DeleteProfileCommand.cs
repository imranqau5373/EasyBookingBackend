using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile.Dto
{
    public class DeleteProfileCommand : IRequest<DeleteProfileResponse>
    {
        public long Id { get; set; }
    }
}
