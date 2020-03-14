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
        protected string SchemaName { get; }

        public BaseConfiguration(string schemaName)
        {
            this.SchemaName = schemaName;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            MapSchema(builder);
            MapPrimaryKey(builder);
			builder.Property(e => e.IsDeleted).HasDefaultValue(false);

			builder.HasQueryFilter(t => t.IsDeleted == false);
		}

        protected virtual void MapSchema(EntityTypeBuilder<T> builder)
        {
            Type type = typeof(T);
            builder.ToTable(type.Name, SchemaName);
        }

        protected virtual void MapPrimaryKey(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.HasIndex(t => t.Id);

        }
    }
}
