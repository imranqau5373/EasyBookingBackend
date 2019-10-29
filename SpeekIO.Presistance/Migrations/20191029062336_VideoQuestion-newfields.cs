using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class VideoQuestionnewfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ArchiveId",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VideoEndTime",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VideoStartTime",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoEndTime",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "VideoStartTime",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "ArchiveId",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
