using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Infrastructure.Video.Configuration;
using SpeekIO.Infrastructure.Video.Implementation;
using SpeekIO.Infrastructure.Video.Interfaces;
using SpeekIO.Infrastructure.Video.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureVideoService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IVideoService, OpenTokVideoService>();

            return services;
        }

        public static Profile GetMappingProfile()
        {
            return new MappingProfile();
        }
    }
}
