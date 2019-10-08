using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }

        public static Profile GetMappingProfile()
        {
            return new MappingProfile();
        }
    }
}
