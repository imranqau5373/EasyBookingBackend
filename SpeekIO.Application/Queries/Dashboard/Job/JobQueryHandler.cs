using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Dashboard.Job
{
    public class JobQueryHandler : IRequestHandler<JobQuery, JobResponse>
    {
        private readonly ILogger<JobQueryHandler> _logger;
        public JobQueryHandler(ILogger<JobQueryHandler> logger)
        {
            this._logger = logger;
        }

        public Task<JobResponse> Handle(JobQuery request, CancellationToken cancellationToken)
        {
            var s = await methodAsync();
            return new JobResponse()
            {
                pageSize = 10
            };
        }
    }
}
