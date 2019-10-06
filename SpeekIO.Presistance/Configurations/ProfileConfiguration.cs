using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Identity;
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
            //builder.HasOne(t => t.User)
            //       .WithOne(t => t.UserProfile)
            //       .HasForeignKey<ApplicationUser>(t => t.Id);
        }
    }
}
