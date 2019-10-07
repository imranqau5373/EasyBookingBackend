using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.EmailService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, Implementation.EmailService>();
            return services;
        }
    }
}
