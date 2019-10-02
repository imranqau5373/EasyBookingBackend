using Microsoft.Extensions.Configuration;
using SpeekIO.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Configuration
{
    internal class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration configuration;

        public ApplicationConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
