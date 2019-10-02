using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Common.Extensions;
using SpeekIO.Presistence.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.ApplicationModule
{
    public static class ApplicationModule
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCommonServices(configuration);
            services.ConfigurePersistence(configuration);

            // register all dependencies here

            return services;
        }
    }
}
