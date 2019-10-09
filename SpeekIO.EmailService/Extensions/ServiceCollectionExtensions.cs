using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Interfaces;
using SpeekIO.EmailService.Implementation;
using SpeekIO.EmailService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpeekIO.EmailService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailConfiguration, EmailConfiguration>();
            services.AddTransient<IEmailService, Implementation.EmailService>();

            services.ConfigureEmailProvider(configuration);

            return services;
        }

        private static IServiceCollection ConfigureEmailProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MailgunEmailProvider>();
            services.AddScoped<MandrillEmailProvider>();

            services.AddScoped<Func<string, IEmailProvider>>(provider => (key) =>
            {
                switch (key)
                {
                    case "Mailgun": return provider.GetRequiredService<MailgunEmailProvider>();
                    case "Mandrill":
                    default:
                        return provider.GetRequiredService<MandrillEmailProvider>();
                }
            });

            return services;
        }
    }
}
