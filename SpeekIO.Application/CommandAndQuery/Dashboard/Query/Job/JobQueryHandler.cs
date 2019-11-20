using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Dashboard.Job
{
    public class JobQueryHandler : IRequestHandler<JobQuery, JobResponse>
    {
        private readonly ILogger<JobQueryHandler> _logger;
        private readonly ISpeekIODbContext _context;
        public JobQueryHandler(ILogger<JobQueryHandler> logger, ISpeekIODbContext context)
        {
            this._logger = logger;
            _context = context;
        }

        public async Task<JobResponse> Handle(JobQuery request, CancellationToken cancellationToken)
        {
            var company = await GetCompany() ;
            return new JobResponse()
            {
                pageSize = 10
            };
        }

        private async Task<Company> GetCompany()
        {
            var company = await _context.Companies.FirstOrDefaultAsync();
            return company;
        }
    }
}
