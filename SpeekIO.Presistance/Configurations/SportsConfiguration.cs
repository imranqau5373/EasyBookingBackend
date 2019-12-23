using EasyBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations
{
	public class SportsConfiguration : BaseConfiguration<Sports>, IEntityTypeConfiguration<Sports>
	{
		public SportsConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<Sports> builder)
		{
			base.Configure(builder);
		}
	}
}
