using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.QuestionConfigurations
{
	public class QuestionTypeConfigurations : BaseConfiguration<QuestionType>, IEntityTypeConfiguration<QuestionType>
	{


		public QuestionTypeConfigurations(string schemaName) : base(schemaName)
		{

		}
		public override void Configure(EntityTypeBuilder<QuestionType> builder)
		{
			base.Configure(builder);
		}
	}
}
