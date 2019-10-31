using SpeekIO.Domain.Entities.Other;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Job
{
    public class Job : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int? MinWorkHours { get; set; }
        public int? MaxWorkHours { get; set; }
        public long JobStatusId { get; set; }
        public long? JobCategoryId { get; set; }
        public long? EmploymentTypeId { get; set; }
        public long LanguageId { get; set; }
        public long? QualificationId { get; set; }
        public JobStatus JobStatus { get; set; }
        public JobCategory JobCategory { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Qualification Qualification { get; set; }
        public Language Language { get; set; }
    }
}
