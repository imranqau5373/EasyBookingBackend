using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.JobConfigurations
{
    public class EmploymentTypeConfiguration : BaseConfiguration<EmploymentType>, IEntityTypeConfiguration<EmploymentType>
    {
        public EmploymentTypeConfiguration(string schemaName) : base(schemaName)
        {

        }
    }
}
