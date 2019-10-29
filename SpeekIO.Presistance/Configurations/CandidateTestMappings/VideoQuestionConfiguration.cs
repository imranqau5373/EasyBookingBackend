using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.CandidateTestEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.CandidateTestMappings
{
	public class VideoQuestionConfiguration : BaseConfiguration<VideoQuestion>, IEntityTypeConfiguration<VideoQuestion>
	{

		public VideoQuestionConfiguration(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<VideoQuestion> builder)
		{
			base.Configure(builder);
		}
	}
}
