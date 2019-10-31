﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeekIO.Presistence.Context;

namespace SpeekIO.Presistence.Migrations
{
    [DbContext(typeof(SpeekIOContext))]
    [Migration("20191029051940_addedLanguageTbl")]
    partial class addedLanguageTbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowRecordingOfHost");

                    b.Property<bool>("AllowRecordingOfParticipants");

                    b.Property<bool>("AutoAcceptConference");

                    b.Property<long?>("CompanyId");

                    b.Property<long?>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("EnableAudio");

                    b.Property<bool>("EnableVideo");

                    b.Property<bool>("IsBroadcast");

                    b.Property<bool>("IsPublic");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<bool>("RecordAutomatically");

                    b.Property<string>("ResolutionHeight");

                    b.Property<string>("ResolutionWidth");

                    b.Property<DateTime?>("ScheduledEndTime");

                    b.Property<DateTime?>("ScheduledStartTime");

                    b.Property<string>("SessionIdentifier");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Id");

                    b.ToTable("ConferenceSession","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSessionEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ConferenceSessionId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("EventType");

                    b.Property<string>("Message");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceSessionId");

                    b.HasIndex("Id");

                    b.ToTable("ConferenceSessionEvent","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.Connection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("IpAddress");

                    b.Property<bool>("IsWebRtcSupported");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<long?>("ParticipantId");

                    b.Property<string>("ReferrerUrl");

                    b.Property<int>("State");

                    b.Property<string>("Url");

                    b.Property<string>("UserAgent");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Connection","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.Participant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ConferenceSessionId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("JoinedOn");

                    b.Property<DateTime?>("LeftOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("ParticipantType");

                    b.Property<long?>("ProfileId");

                    b.Property<DateTime?>("RequestedToJoinOn");

                    b.Property<string>("ResolutionHeight");

                    b.Property<string>("ResolutionWidth");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceSessionId");

                    b.HasIndex("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Participant","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.RecordSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("EnableAudio");

                    b.Property<bool>("EnableVideo");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<long?>("ParticipantId");

                    b.Property<string>("ResolutionHeight");

                    b.Property<string>("ResolutionWidth");

                    b.Property<string>("SessionIdentifier");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("RecordSession","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.SessionArchive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ArchiveId");

                    b.Property<long?>("ConferenceSessionId");

                    b.Property<long>("CreatedAt");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("Duration");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("PartnerId");

                    b.Property<string>("Password");

                    b.Property<string>("Reason");

                    b.Property<long?>("RecordSessionId");

                    b.Property<string>("SessionId");

                    b.Property<long>("Size");

                    b.Property<int>("Status");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceSessionId");

                    b.HasIndex("Id");

                    b.HasIndex("RecordSessionId");

                    b.ToTable("SessionArchive","Communication");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("ApplicationUser","User");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Identity.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Job.EmploymentType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EmploymentType");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Job.JobCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("JobCategory","Job");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Job.Qualification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Qualification","Job");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Other.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Portfolio.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<string>("SubDomainPrefix");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Company","Portfolio");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Portfolio.Profile", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long?>("CompanyId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<bool>("OptInNewsletter");

                    b.Property<string>("Phone");

                    b.Property<string>("Timezone");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profile","Portfolio");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.UmbracoEntities.ContactUs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("ContactUs","Umbraco");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.UmbracoEntities.SubscribeEmail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("EmailAddress");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<bool>("isSubscribed");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("SubscribeEmail","Umbraco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSession", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Profile", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSessionEvent", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSession", "ConferenceSession")
                        .WithMany("ConferenceSessionEvents")
                        .HasForeignKey("ConferenceSessionId");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.Connection", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.Participant", "Participant")
                        .WithMany("Connections")
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.Participant", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSession", "ConferenceSession")
                        .WithMany("Participants")
                        .HasForeignKey("ConferenceSessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.RecordSession", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.CommunicationEntities.SessionArchive", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.ConferenceSession")
                        .WithMany("Archives")
                        .HasForeignKey("ConferenceSessionId");

                    b.HasOne("SpeekIO.Domain.Entities.CommunicationEntities.RecordSession")
                        .WithMany("Archives")
                        .HasForeignKey("RecordSessionId");
                });

            modelBuilder.Entity("SpeekIO.Domain.Entities.Portfolio.Profile", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Company", "Company")
                        .WithMany("Profiles")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
