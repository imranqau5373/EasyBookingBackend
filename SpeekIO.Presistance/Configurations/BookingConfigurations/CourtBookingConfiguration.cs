using EasyBooking.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Presistence.Configurations.BookingConfigurations
{
	public class CourtBookingConfiguration : BaseConfiguration<CourtBookings>, IEntityTypeConfiguration<CourtBookings>
	{
		public CourtBookingConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<CourtBookings> builder)
		{
			base.Configure(builder);
		}
	}
}
