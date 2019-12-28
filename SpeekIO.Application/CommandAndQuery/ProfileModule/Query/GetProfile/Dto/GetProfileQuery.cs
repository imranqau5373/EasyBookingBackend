using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile.Dto
{
    public class GetProfileQuery : IRequest<GetProfileResponse>
    {
        public long Id { get; set; }
    }
}
