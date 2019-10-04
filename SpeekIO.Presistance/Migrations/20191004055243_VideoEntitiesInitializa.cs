using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class VideoEntitiesInitializa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Communication");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ConferenceSession",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "RecordSession",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "Communication");
        }
    }
}
