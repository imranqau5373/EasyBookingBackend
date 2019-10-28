using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Job
{
    public class JobCategory : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
