using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.JobManager.GetJob
{
    class GetJobHandler : IRequestHandler<GetJobQuery, GetJobResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetJobHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetJobResponse> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            var job = await _context.Job.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (job == null)
            {
                return new GetJobResponse()
                {
                    Successful = false,
                    Message = "Job not found."
                };
            }
            var response = _mapper.Map<GetJobResponse>(job);
            response.Successful = true;
            return response;
        }
    }
}
