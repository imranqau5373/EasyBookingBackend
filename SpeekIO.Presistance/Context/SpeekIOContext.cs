using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Context
{
    /// <summary>
    /// SpeekIO Database Context
    /// </summary>
    public class SpeekIOContext : IdentityDbContext<ApplicationUser, UserRole, long>, ISpeekIODbContext
    {
        public SpeekIOContext()
        {
        }
        public SpeekIOContext(DbContextOptions options) : base(options)
        {
        }
        // Entities Set
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ConferenceSession> ConferenceSessions { get; set; }
        public DbSet<ConferenceSessionEvent> ConferenceSessionEvents { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RecordSession> RecordSessions { get; set; }
        public DbSet<SessionArchive> SessionArchives { get; set; }

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

            string communicationSchemaName = "Communication";
            modelBuilder.ApplyConfiguration(new ConferenceSessionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ConferenceSessionEventConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ConnectionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new RecordSessionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new SessionArchiveConfiguration(communicationSchemaName));
        }
    }
}
