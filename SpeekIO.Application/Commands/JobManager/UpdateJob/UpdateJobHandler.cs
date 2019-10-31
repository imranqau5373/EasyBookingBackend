﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Job;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.JobManager.UpdateJob
{
    public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, AddJobResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public UpdateJobHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AddJobResponse> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _context.Job.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (job == null)
            {
                return new AddJobResponse()
                {
                    Successful = false,
                    Message = "Job not found"
                };
            }

            job.JobCategoryId = request.CategoryId;
            job.JobStatusId = request.StatusId;
            job.LanguageId = request.LanguageId;
            job.MaxWorkHours = request.MaxWorkHours;
            job.MinWorkHours = request.MinWorkHours;
            job.Name = request.Name;
            job.QualificationId = request.QualificationId;
            job.Reference = request.Reference;
            job.Description = request.Description;
            job.EmploymentTypeId = request.EmploymentTypeId;
            await _context.SaveChangesAsync();

            var updatedJob = _mapper.Map<AddJobResponse>(job);
            updatedJob.Successful = true;
            return updatedJob;
        }
    }
}
