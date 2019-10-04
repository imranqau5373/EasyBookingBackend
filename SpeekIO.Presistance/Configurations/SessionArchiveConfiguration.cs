using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class SessionArchiveConfiguration : BaseConfiguration<SessionArchive>, IEntityTypeConfiguration<SessionArchive>
    {
        public SessionArchiveConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<SessionArchive> builder)
        {
            base.Configure(builder);

        }
    }
}
