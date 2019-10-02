using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Common.Extensions;
using SpeekIO.Infrastructure.ApplicationImplementation;
using SpeekIO.Infrastructure.Configuration;
using SpeekIO.Presistence.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.ApplicationModule
{
    /// <summary>
    /// Register application modules
    /// </summary>
    public static class ApplicationModule
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // register all dependencies here
            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddTransient<IJobOperations, JobOperations>();

            // register other services here
            services.ConfigureCommonServices(configuration);
            services.ConfigurePersistence(configuration);

            return services;
        }
    }
}
