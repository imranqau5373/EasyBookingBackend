using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.JobConfigurations
{
    public class QualificationConfiguration : BaseConfiguration<Qualification>, IEntityTypeConfiguration<Qualification>
    {
        public QualificationConfiguration(string schemaName) : base(schemaName)
        {

        }
    }
}
