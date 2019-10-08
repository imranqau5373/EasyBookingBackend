using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class IdentityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private string schemaName;

        public IdentityConfiguration(string schemaName)
        {
            this.schemaName = schemaName;
        }
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(nameof(ApplicationUser), schemaName);

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.HasIndex(t => t.Id);

        }
    }
}
