﻿using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Job
{
    public class EmploymentType : BaseEntity, IEntity
    {
        public EmploymentType()
        {
            Job = new HashSet<Job>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Job> Job { get; set; }
    }
}
