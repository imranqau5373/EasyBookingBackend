using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.UmbracoEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.UmbracoMappings
{
	public class ContactUsConfigurations : BaseConfiguration<ContactUs>, IEntityTypeConfiguration<ContactUs>
	{

		public ContactUsConfigurations(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<ContactUs> builder)
		{
			base.Configure(builder);
		}
	}
}
