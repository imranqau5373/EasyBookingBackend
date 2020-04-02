using AutoMapper;
using EasyBooking.Application.Modules;
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
using SpeekIO.Presistence.Context;
using SpeekIO.Presistence.Extensions;
using SpeekIO.UploadService.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

            // register other services here
            services.ConfigureCommonServices(configuration);
            services.ConfigureCore(configuration);
            services.ConfigurePersistence(configuration);
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

			Task.Run(() => CreateRolesIfNotExists(services));

			// configure automapper
			var applicationProfile = Application.Modules.ApplicationModule.GetMappingProfile(services);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(applicationProfile);
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

		private static async Task CreateRolesIfNotExists(IServiceCollection services)
		{
			var roleManager = services.BuildServiceProvider().GetService<ApplicationRoleManager>();

			var roles = new List<UserRole>();
			roles.Add(new UserRole { Name = "Admin", IsPublic = false });
			roles.Add(new UserRole { Name = "Super Admin", IsPublic = true });
			roles.Add(new UserRole { Name = "Booking User", IsPublic = true });

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role.Name))
				{
					await roleManager.CreateAsync(role);
					//default user permissions
					if (role.Name == "Admin")
					{
						await AddAdminPermissions(role, roleManager);
					}
					else if (role.Name == "Super Admin")
					{
						await AddSuperAdminPermissions(role, roleManager);
					}
					else if (role.Name == "Booking User")
					{
						await AddBookingUserPermissions(role, roleManager);
					}
				}
			}
			//var adminRole = await roleManager.FindByNameAsync("Admin");
			//await AddAdminPermissions(adminRole, roleManager);

		}

		private static async Task AddAdminPermissions(UserRole role, ApplicationRoleManager roleManager)
		{
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.AdminDashboard.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.CourtsBookingManager.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.CourtsDurationManager.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.AdminUsers.View));
		}
		private static async Task AddSuperAdminPermissions(UserRole role, ApplicationRoleManager roleManager)
		{
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.SuperAdminDashboard.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.SportsManager.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.CourtsManager.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.SuperAdminUsers.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.CourtsBookingManager.View));
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.CourtsDurationManager.View));
		}
		private static async Task AddBookingUserPermissions(UserRole role, ApplicationRoleManager roleManager)
		{
			await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, Permissions.BookingUserDashboard.View));
		}

	}
}
