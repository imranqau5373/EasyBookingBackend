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

        public int RetryCount => configuration.GetSection("Policy")?.GetValue<int>("RetryCount") ?? 0;

        public int Backoff => configuration.GetSection("Policy")?.GetValue<int>("Backoff") ?? 0;

        public string AuthKey => configuration.GetSection("Identity")?.GetValue<string>("AuthKey");

        public string Issuer => configuration.GetSection("Identity")?.GetValue<string>("Issuer");

        public int TokenExpiry => configuration.GetSection("Identity")?.GetValue<int>("TokenExpiry") ?? 0;

        public string Domain => configuration.GetValue<string>("Domain") ?? "localhost:4200";

        public string AdminEmail => configuration.GetSection("Emails")?.GetValue<string>("AdminEmail");

        public string ProfileImagePath => configuration.GetSection("OutputPaths")?.GetValue<string>("ProfileImagePath");
    }
}
