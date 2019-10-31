using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.JobConfigurations
{
    public class JobConfiguration : BaseConfiguration<Job>, IEntityTypeConfiguration<Job>
    {
        public JobConfiguration(string schemaName) : base(schemaName)
        {
        }
        public override void Configure(EntityTypeBuilder<Job> builder)
        {
            base.Configure(builder);
            builder.HasOne(t => t.JobCategory)
                   .WithMany(t => t.Job)
                   .HasForeignKey(t => t.JobCategoryId);
        }
    }
}
