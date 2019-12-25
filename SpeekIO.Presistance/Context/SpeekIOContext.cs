using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Configurations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Presistence.Context
{
	/// <summary>
	/// SpeekIO Database Context
	/// </summary>
	public class SpeekIOContext : IdentityDbContext<ApplicationUser, UserRole, long>
    {
        public SpeekIOContext(DbContextOptions options) : base(options)
        {
        }
        // Entities Set
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profile> Profiles { get; set; }

		public DbSet<Sports> Sports { get; set; }

		public DbSet<Courts> Courts { get; set; }

		public DbSet<CourtBookings> CourtsDurations { get; set; }

		public DbSet<CourtsDurations> CourtsBookings { get; set; }

		/// <summary>
		/// Apply Configurations to the model here
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string portfolioSchemaName = "Portfolio";
            modelBuilder.ApplyConfiguration(new CompaniesConfiguration(portfolioSchemaName));
            modelBuilder.ApplyConfiguration(new ProfileConfiguration(portfolioSchemaName));

            string üserDataSchemaName = "User";
            modelBuilder.ApplyConfiguration(new IdentityConfiguration(üserDataSchemaName));

        }


		public async Task<int> SaveChangesAsync(ApplicationUser currentUser, CancellationToken cancellationToken = default)
		{
			var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
			foreach (var entity in entities)
			{
				if (entity.State == EntityState.Added)
				{
					((BaseEntity)entity.Entity).CreatedBy = currentUser.Id;
				}
				if (entity.State == EntityState.Modified)
				{
					((BaseEntity)entity.Entity).CreatedBy = currentUser.Id;
				}
				((BaseEntity)entity.Entity).ModifiedBy = currentUser.Id;
			}
			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
