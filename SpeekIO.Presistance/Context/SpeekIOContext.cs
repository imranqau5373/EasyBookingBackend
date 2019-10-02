using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities;
using SpeekIO.Presistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Presistence.Context
{
    /// <summary>
    /// SpeekIO Database Context
    /// </summary>
    public class SpeekIOContext : DbContext
    {
        public SpeekIOContext()
        {
        }
        public SpeekIOContext(DbContextOptions options) : base(options)
        {
        }
        // Entities Set
        public DbSet<Attachment> Attachments { get; set; }

        /// <summary>
        /// Apply Configurations to the model here
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }
    }
}
