using Microsoft.Extensions.Configuration;
using SpeekIO.EmailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.EmailService.Implementation
{
    internal class EmailConfiguration : IEmailConfiguration
    {
        private readonly IConfiguration _configuration;

        public EmailConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DefaultProvider => _configuration.GetSection("Email").GetValue<string>("DefaultProvider");

        public string MandrillAPIKey => _configuration.GetSection("Email").GetSection("Mandrill").GetValue<string>("ApiKey");

        public string MandrillSenderEmail => _configuration.GetSection("Email").GetSection("Mandrill").GetValue<string>("SenderEmail");
    }
}
