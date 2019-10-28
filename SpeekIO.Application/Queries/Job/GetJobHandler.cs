using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using SpeekIO.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace SpeekIO.Application.Queries.Job
{
    public class GetJobHandler : IRequestHandler<GetJobQuery, GetJobResponse>
    {
        private readonly ILogger<GetJobHandler> _logger;
        private readonly ISpeekIODbContext _context;

        public GetJobHandler(ILogger<GetJobHandler> logger, ISpeekIODbContext context)
        {
            this._logger = logger;
            _context = context;
        }

        public async Task<GetJobResponse> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            return new GetJobResponse();
        }
    }
}
