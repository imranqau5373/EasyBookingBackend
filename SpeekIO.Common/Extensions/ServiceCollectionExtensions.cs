using EasyBooking.Common.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Common.HttpClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISpeekIOHttpClient, SpeekIOHttpClient>();
			services.AddScoped<IUserSession, UserSession>();
			return services;
        }
    }
}
