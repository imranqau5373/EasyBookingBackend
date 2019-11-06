using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Modules;
using SpeekIO.Common.Extensions;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.EmailService.Extensions;
using SpeekIO.Infrastructure.Configuration;
using SpeekIO.Infrastructure.Mapping;
using SpeekIO.Infrastructure.Video.Configuration;
using SpeekIO.Infrastructure.Video.Extensions;
using SpeekIO.Presistence.Context;
using SpeekIO.Presistence.Extensions;
using SpeekIO.UploadService.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            services.AddSingleton<IVideoConfiguration, VideoConfiguration>();

            // register other services here
            services.ConfigureCommonServices(configuration);
            services.ConfigureCore(configuration);
            services.ConfigurePersistence(configuration);
            services.ConfigureVideoService(configuration);
            services.ConfigureEmailService(configuration);
            services.ConfigureUploadService();

            services.AddIdentity<ApplicationUser, UserRole>()
                        .AddEntityFrameworkStores<SpeekIOContext>()
                        .AddUserManager<ApplicationUserManager>()
                        .AddSignInManager<ApplicationSignInManager>()
                        .AddRoleManager<ApplicationRoleManager>()
                        .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });

            CreateRolesIfNotExists(services);

            // configure automapper
            var applicationProfile = Application.Modules.ApplicationModule.GetMappingProfile(services);
            var videoProfile = Video.Extensions.ServiceCollectionExtensions.GetMappingProfile();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(applicationProfile);
                mc.AddProfile(videoProfile);
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static async Task CreateRolesIfNotExists(IServiceCollection services)
        {
            var roleManager = services.BuildServiceProvider().GetService<ApplicationRoleManager>();

            var roles = new List<string>();

            roles.Add(UserRoles.SystemAdmin.ToString());
            roles.Add(UserRoles.Admin.ToString());
            roles.Add(UserRoles.HRManager.ToString());
            roles.Add(UserRoles.User.ToString());
            roles.Add(UserRoles.GuestUser.ToString());

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var identityRole = new UserRole();
                    identityRole.Name = role;

                    await roleManager.CreateAsync(identityRole);
                }
            }
        }
    }
}
