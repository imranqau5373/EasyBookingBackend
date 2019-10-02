using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Infrastructure.Video.Configuration;
using SpeekIO.Infrastructure.Video.Implementation;
using SpeekIO.Infrastructure.Video.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureVideoService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IVideoConfiguration, VideoConfiguration>();
            services.AddSingleton<IVideoService, OpenTokVideoService>();

            return services;
        }
    }
}
