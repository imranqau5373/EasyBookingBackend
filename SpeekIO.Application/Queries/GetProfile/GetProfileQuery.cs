using MediatR;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse.QueryResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<GetProfileResponse>
    {
    }
}
