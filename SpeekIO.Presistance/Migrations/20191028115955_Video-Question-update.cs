using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class VideoQuestionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoEndTime",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "VideoStartTime",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.RenameColumn(
                name: "Token",
                schema: "CandidateTest",
                table: "VideoQuestion",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ArchiveUrl",
                schema: "CandidateTest",
                table: "VideoQuestion",
                newName: "Resolution");

            migrationBuilder.AddColumn<long>(
                name: "CreatedAt",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Duration",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "HasAudio",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasVideo",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "HasAudio",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "HasVideo",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "Reason",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "Size",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "CandidateTest",
                table: "VideoQuestion",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "Resolution",
                schema: "CandidateTest",
                table: "VideoQuestion",
                newName: "ArchiveUrl");

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
    }
}
