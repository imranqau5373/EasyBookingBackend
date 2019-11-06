using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities;
using SpeekIO.Domain.Entities.CandidateTestEntities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Job;
using SpeekIO.Domain.Entities.Other;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Entities.UmbracoEntities;
using SpeekIO.Presistence.Configurations;
using SpeekIO.Presistence.Configurations.CandidateTestMappings;
using SpeekIO.Presistence.Configurations.JobConfigurations;
using SpeekIO.Presistence.Configurations.UmbracoMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Presistence.Context
{
    /// <summary>
    /// SpeekIO Database Context
    /// </summary>
    public class SpeekIOContext : IdentityDbContext<ApplicationUser, UserRole, long>, ISpeekIODbContext
    {
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
        //Umbraco related Entities
        public DbSet<SubscribeEmail> SubscribeEmails { get; set; }


        //Candidate Test Entities
        public DbSet<VideoQuestion> VideoQuestions { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<EmploymentType> EmploymentType { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
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


            string umbracoSchemaName = "Umbraco";
            modelBuilder.ApplyConfiguration(new SubscribeEamilConfiguration(umbracoSchemaName));
            modelBuilder.ApplyConfiguration(new ContactUsConfigurations(umbracoSchemaName));



            string candidateTestSchemaName = "CandidateTest";
            modelBuilder.ApplyConfiguration(new VideoQuestionConfiguration(candidateTestSchemaName));

            string communicationSchemaName = "Communication";
            modelBuilder.ApplyConfiguration(new ConferenceSessionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ConferenceSessionEventConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ConnectionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new RecordSessionConfiguration(communicationSchemaName));
            modelBuilder.ApplyConfiguration(new SessionArchiveConfiguration(communicationSchemaName));

            string jobSchemaName = "Job";
            //modelBuilder.ApplyConfiguration(new EmploymentTypeConfiguration(jobSchemaName));
            modelBuilder.ApplyConfiguration(new JobCategoryConfiguration(jobSchemaName));
            modelBuilder.ApplyConfiguration(new QualificationConfiguration(jobSchemaName));
            modelBuilder.ApplyConfiguration(new JobConfiguration(jobSchemaName));
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
                ((BaseEntity)entity.Entity).ModifiedBy = currentUser.Id;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
