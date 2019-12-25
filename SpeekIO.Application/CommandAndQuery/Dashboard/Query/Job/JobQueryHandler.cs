using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Dashboard.Job
{
    public class JobQueryHandler : IRequestHandler<JobQuery, CommonResponse>
    {
        private readonly ILogger<JobQueryHandler> _logger;
        private readonly SpeekIOContext _context;
        public JobQueryHandler(ILogger<JobQueryHandler> logger, SpeekIOContext context)
        {
            this._logger = logger;
            _context = context;
        }

        public async Task<CommonResponse> Handle(JobQuery request, CancellationToken cancellationToken)
        {
            var company = await GetCompany() ;
            return new CommonResponse()
            {
                Successful = true
            };
        }

        private async Task<Company> GetCompany()
        {
            var company = await _context.Companies.FirstOrDefaultAsync();
            return company;
        }
    }
}
