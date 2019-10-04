using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class ConferenceSessionEventConfiguration : BaseConfiguration<ConferenceSessionEvent>, IEntityTypeConfiguration<ConferenceSessionEvent>
    {
        public ConferenceSessionEventConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<ConferenceSessionEvent> builder)
        {
            base.Configure(builder);

        }
    }
}
