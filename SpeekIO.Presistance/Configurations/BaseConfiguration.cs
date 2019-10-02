using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasIndex(t => t.Id);
            builder.HasKey(t => t.Id);
        }
    }
}
