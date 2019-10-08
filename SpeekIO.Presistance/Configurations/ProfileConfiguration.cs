using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class ProfileConfiguration : BaseConfiguration<Profile>, IEntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            base.Configure(builder);
            builder.HasOne(t => t.Company)
                   .WithMany(t => t.Profiles)
                   .HasForeignKey(t => t.CompanyId);

        }
    }
}
