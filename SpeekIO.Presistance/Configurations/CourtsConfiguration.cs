using EasyBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations
{
	public class CourtsConfiguration : BaseConfiguration<Courts>, IEntityTypeConfiguration<Courts>
	{
		public CourtsConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<Courts> builder)
		{
			base.Configure(builder);
		}
	}
}
