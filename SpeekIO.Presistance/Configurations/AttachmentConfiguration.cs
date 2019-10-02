using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class AttachmentConfiguration : BaseConfiguration<Attachment>, IEntityTypeConfiguration<Attachment>
    {
        private readonly string Schema = "Common";
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            base.Configure(builder);

            builder.HasKey(t => t.AttachmentGuid);
            builder.ToTable(nameof(Attachment), Schema);
        }
    }
}
