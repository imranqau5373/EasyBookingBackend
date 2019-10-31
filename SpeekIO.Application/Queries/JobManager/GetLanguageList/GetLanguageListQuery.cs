using MediatR;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.Job.GetLanguageList
{
    public class GetLanguageListQuery : IRequest<GetLanguageListResponse>
    {
    }
}
