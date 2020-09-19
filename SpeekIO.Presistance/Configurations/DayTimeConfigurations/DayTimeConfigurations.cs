using EasyBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations.DayTimeConfigurations
{
    public class DayTimeConfigurations : BaseConfiguration<DayTimeSchedule>, IEntityTypeConfiguration<DayTimeSchedule>
    {
		public DayTimeConfigurations(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<DayTimeSchedule> builder)
		{
			base.Configure(builder);
		}

	}
}
