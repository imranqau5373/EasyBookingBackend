using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.Identity;

using SpeekIO.Domain.Entities.Portfolio;

using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Interfaces
{
    public interface ISpeekIODbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Profile> Profiles { get; set; }
		DbSet<Sports> Sports { get; set; }

		DbSet<Courts> Courts { get; set; }

		DbSet<CourtBookings> CourtsDurations { get; set; }

		DbSet<CourtsDurations> CourtsBookings { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(ApplicationUser currentUser, CancellationToken cancellationToken = default);
	}
}
