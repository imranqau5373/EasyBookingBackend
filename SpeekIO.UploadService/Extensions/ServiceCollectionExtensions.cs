using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Interfaces.UploadService;
using SpeekIO.UploadService.Implementation;
using SpeekIO.UploadService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.UploadService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureUploadService(this IServiceCollection services)
        {
            services.AddTransient<IUploadConfiguration, UploadConfiguration>();
            services.AddTransient<IUploadService, Implementation.UploadService>();
            return services;
        }
    }
}
