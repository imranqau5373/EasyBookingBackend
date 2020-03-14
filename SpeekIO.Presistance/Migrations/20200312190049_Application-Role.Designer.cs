﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeekIO.Presistence.Context;

namespace EasyBooking.Presistence.Migrations
{
    [DbContext(typeof(SpeekIOContext))]
    [Migration("20200312190049_Application-Role")]
    partial class ApplicationRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyBooking.Domain.Entities.Bookings.CourtBookings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BookingEndTime");

                    b.Property<DateTime?>("BookingStartTime");

                    b.Property<long?>("CourtsDurationsId");

                    b.Property<long?>("CourtsId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<long>("DurationId");

                    b.Property<bool>("IsBooked");

                    b.Property<bool>("IsEmailed");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<long?>("ProfileId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourtsDurationsId");

                    b.HasIndex("CourtsId");

                    b.HasIndex("ProfileId");

                    b.ToTable("CourtsBookings");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Bookings.CourtsDurations", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CourtDate");

                    b.Property<DateTime?>("CourtEndTime");

                    b.Property<DateTime?>("CourtStartTime");

                    b.Property<long?>("CourtsId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<long>("DurationStatusId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("SlotDuration");

                    b.HasKey("Id");

                    b.HasIndex("CourtsId");

                    b.HasIndex("DurationStatusId");

                    b.ToTable("CourtsDurations");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Bookings.DurationStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DurationStatus");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Courts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<long?>("SportsId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SportsId");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Sports", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<long>");
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

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<long>");
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

                    b.Property<bool>("IsPublic");

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

            modelBuilder.Entity("SpeekIO.Domain.Entities.Portfolio.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

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

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<bool>("OptInNewsletter");

                    b.Property<string>("Phone");

                    b.Property<string>("PictureThumbnailUrl");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("Timezone");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profile","Portfolio");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>");

                    b.Property<long?>("RoleId1");

                    b.HasIndex("RoleId1");

                    b.HasDiscriminator().HasValue("ApplicationRoleClaim");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Identity.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<long>");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<long?>("RoleId1");

                    b.Property<long?>("UserId1");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Bookings.CourtBookings", b =>
                {
                    b.HasOne("EasyBooking.Domain.Entities.Bookings.CourtsDurations", "CourtsDurations")
                        .WithMany("CourtBookings")
                        .HasForeignKey("CourtsDurationsId");

                    b.HasOne("EasyBooking.Domain.Entities.Courts", "Courts")
                        .WithMany("CourtBookings")
                        .HasForeignKey("CourtsId");

                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Profile", "Profile")
                        .WithMany("CourtBookings")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Bookings.CourtsDurations", b =>
                {
                    b.HasOne("EasyBooking.Domain.Entities.Courts", "Courts")
                        .WithMany("CourtsDurations")
                        .HasForeignKey("CourtsId");

                    b.HasOne("EasyBooking.Domain.Entities.Bookings.DurationStatus", "DurationStatus")
                        .WithMany()
                        .HasForeignKey("DurationStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Courts", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Company", "Company")
                        .WithMany("Courts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EasyBooking.Domain.Entities.Sports", "Sports")
                        .WithMany("Courts")
                        .HasForeignKey("SportsId");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Sports", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Company", "Company")
                        .WithMany("Sports")
                        .HasForeignKey("CompanyId");
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

            modelBuilder.Entity("SpeekIO.Domain.Entities.Portfolio.Profile", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Portfolio.Company", "Company")
                        .WithMany("Profiles")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.UserRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId1");
                });

            modelBuilder.Entity("EasyBooking.Domain.Entities.Identity.ApplicationUserRole", b =>
                {
                    b.HasOne("SpeekIO.Domain.Entities.Identity.UserRole", "Role")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("SpeekIO.Domain.Entities.Identity.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
