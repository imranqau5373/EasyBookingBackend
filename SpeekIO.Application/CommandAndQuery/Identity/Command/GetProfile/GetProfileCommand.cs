using MediatR;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse.CommandResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.GetProfile
{
    public class GetProfileCommand : IRequest<GetProfileResponse>
    {
    }
}
