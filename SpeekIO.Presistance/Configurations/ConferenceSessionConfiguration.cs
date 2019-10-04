using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class ConferenceSessionConfiguration : BaseConfiguration<ConferenceSession>, IEntityTypeConfiguration<ConferenceSession>
    {
        public ConferenceSessionConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<ConferenceSession> builder)
        {
            base.Configure(builder);

        }
    }
}
