using Microsoft.Extensions.Configuration;
using SpeekIO.UploadService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.UploadService.Implementation
{
    class UploadConfiguration : IUploadConfiguration
    {
        private readonly IConfiguration _configuration;
        public UploadConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string StorageConnectionString => _configuration.GetSection("Storage").GetSection("Azure").GetValue<string>("StorageConnectionString");

    }
}
