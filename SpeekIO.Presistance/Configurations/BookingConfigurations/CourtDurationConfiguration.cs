using EasyBooking.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations.BookingConfigurations
{
	public class CourtDurationConfiguration : BaseConfiguration<CourtsDurations>, IEntityTypeConfiguration<CourtsDurations>
	{
		public CourtDurationConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<CourtsDurations> builder)
		{
			base.Configure(builder);
		}
	}
}
