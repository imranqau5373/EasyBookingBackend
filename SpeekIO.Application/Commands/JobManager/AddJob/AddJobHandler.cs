using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Job;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.JobManager.AddJob
{
    public class AddJobHandler : CommandHandlerBase<AddJobCommand, AddJobResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public AddJobHandler(
            ISpeekIODbContext context,
            IMapper mapper,
            ApplicationUserManager userManager,
            IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<AddJobResponse> Handle(AddJobCommand request, CancellationToken cancellationToken)
        {
            var jobModel = _mapper.Map<Job>(request);
            var job = await _context.Job.AddAsync(jobModel);
            await _context.SaveChangesAsync(User);
            if (job.Entity.Id < 1)
            {
                return new AddJobResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while adding job."
                };
            }
            var jobResponse = _mapper.Map<AddJobResponse>(job.Entity);
            jobResponse.Successful = true;
            return jobResponse;
        }
    }
}
