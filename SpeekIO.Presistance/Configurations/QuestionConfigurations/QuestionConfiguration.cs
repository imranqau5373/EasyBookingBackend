using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.QuestionConfigurations
{
    class QuestionConfiguration : BaseConfiguration<Question>, IEntityTypeConfiguration<Question>
    {

        public QuestionConfiguration(string schemaName) : base(schemaName)
        {
        }
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);
        }
    }
}
