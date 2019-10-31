using MediatR;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.JobManager.GetJob
{
    public class GetJobQuery : IRequest<GetJobResponse>
    {
        public long Id { get; set; }
    }
}
