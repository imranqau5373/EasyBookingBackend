using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class ConnectionConfiguration : BaseConfiguration<Connection>, IEntityTypeConfiguration<Connection>
    {
        public ConnectionConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<Connection> builder)
        {
            base.Configure(builder);

        }
    }
}
