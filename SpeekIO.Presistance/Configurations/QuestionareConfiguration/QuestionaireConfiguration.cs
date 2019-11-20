using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Question;
using SpeekIO.Domain.Entities.Questionaire;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations.QuestionareConfiguration
{
    public class QuestionaireConfiguration : BaseConfiguration<Questionaire>, IEntityTypeConfiguration<Questionaire>
    {
        public QuestionaireConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<Questionaire> builder)
        {
            base.Configure(builder);
            builder.HasMany(t=>t.Questions)
                   .WithOne(t=>t.Questionaire)
                   .HasForeignKey(t => t.QuestionaireId);

        }
    }
}
