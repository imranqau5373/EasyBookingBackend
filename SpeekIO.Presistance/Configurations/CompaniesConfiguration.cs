using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeekIO.Domain.Entities.Portfolio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Configurations
{
    public class CompaniesConfiguration : BaseConfiguration<Company>, IEntityTypeConfiguration<Company>
    {
        public CompaniesConfiguration(string schemaName) : base(schemaName)
        {

        }
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
        }
    }
}
