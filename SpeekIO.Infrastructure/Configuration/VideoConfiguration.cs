using Microsoft.Extensions.Configuration;
using SpeekIO.Infrastructure.Video.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Configuration
{
    internal class VideoConfiguration : IVideoConfiguration
    {
        private readonly IConfiguration _configuration;

        public VideoConfiguration(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string ApiKey => _configuration.GetSection("Video")?.GetValue<string>("ApiKey") ?? "";

        public string ApiSecret => _configuration.GetSection("Video")?.GetValue<string>("ApiSecret") ?? "";

        public int RetryCount => _configuration.GetSection("Policy")?.GetValue<int>("RetryCount") ?? 0;

        public int Backoff => _configuration.GetSection("Policy")?.GetValue<int>("Backoff") ?? 0;
    }
}
