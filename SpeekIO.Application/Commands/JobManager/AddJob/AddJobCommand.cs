using MediatR;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.JobManager.AddJob
{
    public class AddJobCommand : IRequest<AddJobResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public long StatusId { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int? EmploymentTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? QualificationId { get; set; }
        public int? MinWorkHours { get; set; }
        public int? MaxWorkHours { get; set; }
    }
}
