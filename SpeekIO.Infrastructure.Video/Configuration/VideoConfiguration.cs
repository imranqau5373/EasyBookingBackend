using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Configuration
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
    }
}
