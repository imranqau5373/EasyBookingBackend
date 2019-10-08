using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Communication");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Portfolio");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceSession",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    SessionIdentifier = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EnableAudio = table.Column<bool>(nullable: false),
                    EnableVideo = table.Column<bool>(nullable: false),
                    ResolutionWidth = table.Column<string>(nullable: true),
                    ResolutionHeight = table.Column<string>(nullable: true),
                    ScheduledStartTime = table.Column<DateTime>(nullable: false),
                    ScheduledEndTime = table.Column<DateTime>(nullable: false),
                    IsBroadcast = table.Column<bool>(nullable: false),
                    RecordAutomatically = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    AutoAcceptConference = table.Column<bool>(nullable: false),
                    AllowRecordingOfHost = table.Column<bool>(nullable: false),
                    AllowRecordingOfParticipants = table.Column<bool>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ParticipantType = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    RequestedToJoinOn = table.Column<DateTime>(nullable: true),
                    JoinedOn = table.Column<DateTime>(nullable: true),
                    LeftOn = table.Column<DateTime>(nullable: true),
                    ResolutionWidth = table.Column<string>(nullable: true),
                    ResolutionHeight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    SubDomainPrefix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceSessionEvent",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ConferenceSessionId = table.Column<long>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceSessionEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConferenceSessionEvent_ConferenceSession_ConferenceSessionId",
                        column: x => x.ConferenceSessionId,
                        principalSchema: "Communication",
                        principalTable: "ConferenceSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ParticipantId = table.Column<long>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    ConnectionId = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    ReferrerUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsWebRtcSupported = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connection_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "Communication",
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordSession",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    SessionIdentifier = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EnableAudio = table.Column<bool>(nullable: false),
                    EnableVideo = table.Column<bool>(nullable: false),
                    ResolutionWidth = table.Column<string>(nullable: true),
                    ResolutionHeight = table.Column<string>(nullable: true),
                    ParticipantId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordSession_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "Communication",
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Timezone = table.Column<string>(nullable: true),
                    OptInNewsletter = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portfolio",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionArchive",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    ArchiveId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PartnerId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConferenceSessionId = table.Column<long>(nullable: true),
                    RecordSessionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionArchive_ConferenceSession_ConferenceSessionId",
                        column: x => x.ConferenceSessionId,
                        principalSchema: "Communication",
                        principalTable: "ConferenceSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionArchive_RecordSession_RecordSessionId",
                        column: x => x.RecordSessionId,
                        principalSchema: "Communication",
                        principalTable: "RecordSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSession_Id",
                schema: "Communication",
                table: "ConferenceSession",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSessionEvent_ConferenceSessionId",
                schema: "Communication",
                table: "ConferenceSessionEvent",
                column: "ConferenceSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSessionEvent_Id",
                schema: "Communication",
                table: "ConferenceSessionEvent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_Id",
                schema: "Communication",
                table: "Connection",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ParticipantId",
                schema: "Communication",
                table: "Connection",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_Id",
                schema: "Communication",
                table: "Participant",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecordSession_Id",
                schema: "Communication",
                table: "RecordSession",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecordSession_ParticipantId",
                schema: "Communication",
                table: "RecordSession",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionArchive_ConferenceSessionId",
                schema: "Communication",
                table: "SessionArchive",
                column: "ConferenceSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionArchive_Id",
                schema: "Communication",
                table: "SessionArchive",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SessionArchive_RecordSessionId",
                schema: "Communication",
                table: "SessionArchive",
                column: "RecordSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                schema: "Portfolio",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CompanyId",
                schema: "Portfolio",
                table: "Profile",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Id",
                schema: "Portfolio",
                table: "Profile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                schema: "Portfolio",
                table: "Profile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_Id",
                schema: "User",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "User",
                table: "ApplicationUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "User",
                table: "ApplicationUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConferenceSessionEvent",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "Connection",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "SessionArchive",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "Portfolio");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ConferenceSession",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "RecordSession",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Portfolio");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "Communication");
        }
    }
}
