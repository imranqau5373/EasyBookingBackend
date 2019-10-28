using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.JobConfigurations
{
    public class JobCategoryConfiguration : BaseConfiguration<JobCategory>, IEntityTypeConfiguration<JobCategory>
    {
        public JobCategoryConfiguration(string schemaName) : base(schemaName)
        {

        }
    }
}
