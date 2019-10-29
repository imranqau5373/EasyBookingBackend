using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class VideoQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CandidateTest");

            migrationBuilder.CreateTable(
                name: "VideoQuestion",
                schema: "CandidateTest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    SessionId = table.Column<string>(nullable: true),
                    ArchiveId = table.Column<string>(nullable: true),
                    VideoStartTime = table.Column<DateTime>(nullable: false),
                    VideoEndTime = table.Column<DateTime>(nullable: false),
                    ArchiveUrl = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoQuestion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoQuestion_Id",
                schema: "CandidateTest",
                table: "VideoQuestion",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoQuestion",
                schema: "CandidateTest");
        }
    }
}
