using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Implementation;
using SpeekIO.Application.Interfaces.Identity;
using SpeekIO.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Modules
{
    public static class ApplicationModule
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            return services;
        }

        public static Profile GetMappingProfile(IServiceCollection services)
        {
            var applicationConfiguration = services.BuildServiceProvider().GetService<IApplicationConfiguration>();
            return new MappingProfile(applicationConfiguration);
        }
    }
}
