﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SpeekIO.Presistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<SpeekIOContext>(builder => builder.UseSqlServer(defaultConnectionString),builder.UseRowNumberForPaging());
            services.AddDbContext<SpeekIOContext>(options => options.UseSqlServer(defaultConnectionString, builder => builder.UseRowNumberForPaging()));
            //services.AddScoped<ISpeekIODbContext>(provider => provider.GetService<SpeekIOContext>());

            // migrate database changes
            var context = services.BuildServiceProvider().GetService<SpeekIOContext>();
            context.Database.Migrate();
            SpeekIODataSeed.Instance(context).SeedEverything(context);

            return services;
        }
    }
}
