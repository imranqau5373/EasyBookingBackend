using EasyBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations.DayTimeConfigurations
{

	public class DayTimeDaysConfigurations : BaseConfiguration<DayTimeDays>, IEntityTypeConfiguration<DayTimeDays>
	{
		public DayTimeDaysConfigurations(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<DayTimeDays> builder)
		{
			base.Configure(builder);
		}

	}
}
