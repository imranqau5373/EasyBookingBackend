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
		public string EmailVerificationEndPoint => configuration.GetSection("URLs")?.GetValue<string>("EmailVerificationEndPoint");
		public string ClientAppUrl => configuration.GetSection("URLs")?.GetValue<string>("ClientAppUrl");
		public string EmailVerificationPageUrl => configuration.GetSection("URLs")?.GetValue<string>("EmailVerificationPageUrl");
		public string APIUrl => configuration.GetSection("URLs")?.GetValue<string>("APIUrl");
		public string AdminEmail => configuration.GetSection("Emails")?.GetValue<string>("AdminEmail");

        public string ProfilePicturePlaceholderUrl => configuration.GetSection("DefaultSettings")?.GetValue<string>("ProfilePicturePlaceholderUrl");

        public string UserAccountsContainerName => configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("UserAccountsContainerName");

        public string DefaultFileExtension => configuration.GetSection("DefaultSettings").GetValue<string>("DefaultFileExtension");

		public string DefaultPassword => configuration.GetSection("DefaultSettings")?.GetValue<string>("DefaultPassword");
        public string DefaultCompanyEmail => configuration.GetSection("DefaultSettings")?.GetValue<string>("DefaultCompanyEmail");


        public string StorageBlobUrl => configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("StorageBlobUrl");
        public string AzureUrlBinding => configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("DefaultBinding");
        public string BaseProfilePictureUrl => configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("DefaultBinding")
            + configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("StorageBlobUrl")
            + "/" + configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("UserAccountsContainerName");

    }
}
