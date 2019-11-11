using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Common.Extensions;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.QueryResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.JobManager.GetJobList
{
    class GetJobListHandler : IRequestHandler<GetJobListQuery, GetJobListResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetJobListHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetJobListResponse> Handle(GetJobListQuery request, CancellationToken cancellationToken)
        {
            var jobs = new List<Domain.Entities.Job.Job>();
            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                jobs = await _context.Job
                    .Where(t => t.JobStatusId == request.StatusId)
                    .Include(t => t.JobStatus)
                    .Page(request.PageNumber, request.PageSize).ToListAsync();
            }
            else
            {
                jobs = await _context.Job
                    .Where(t => t.JobStatusId == request.StatusId)
                    .Include(t => t.JobStatus).ToListAsync();
            }

            var jobList = _mapper.Map<List<GetJobListModel>>(jobs);
            jobList.ForEach(t =>
            {
                t.RelativeTime = t.ModifiedOn.RelativeTime();
            });
            var response = new GetJobListResponse()
            {
                Jobs = jobList,
                Successful = true
            };
            return response;
        }
    }
}
