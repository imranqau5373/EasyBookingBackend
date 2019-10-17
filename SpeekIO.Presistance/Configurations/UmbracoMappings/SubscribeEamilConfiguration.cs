using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Entities.UmbracoEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
	public class SubscribeEamilConfiguration : BaseConfiguration<SubscribeEmail>, IEntityTypeConfiguration<SubscribeEmail>
	{

		public SubscribeEamilConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<SubscribeEmail> builder)
		{
			base.Configure(builder);
		}
	}
}
