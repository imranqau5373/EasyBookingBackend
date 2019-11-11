using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class addedColumnsCreatedModifiedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Umbraco",
                table: "SubscribeEmail",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Umbraco",
                table: "SubscribeEmail",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Umbraco",
                table: "ContactUs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Umbraco",
                table: "ContactUs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Portfolio",
                table: "Company",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Portfolio",
                table: "Company",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Job",
                table: "Qualification",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Job",
                table: "Qualification",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Job",
                table: "JobCategory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Job",
                table: "JobCategory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Job",
                table: "Job",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Job",
                table: "Job",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Communication",
                table: "SessionArchive",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "SessionArchive",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Communication",
                table: "RecordSession",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "RecordSession",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Communication",
                table: "Participant",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "Participant",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Communication",
                table: "Connection",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "Connection",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "Communication",
                table: "ConferenceSessionEvent",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "ConferenceSessionEvent",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "CandidateTest",
                table: "VideoQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Language",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "Language",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "JobStatus",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "JobStatus",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "EmploymentType",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "EmploymentType",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Umbraco",
                table: "SubscribeEmail");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Umbraco",
                table: "SubscribeEmail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Umbraco",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Umbraco",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Job",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Job",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Job",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Job",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Job",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Job",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Communication",
                table: "SessionArchive");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "SessionArchive");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Communication",
                table: "RecordSession");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "RecordSession");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Communication",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Communication",
                table: "ConferenceSessionEvent");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "ConferenceSessionEvent");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "CandidateTest",
                table: "VideoQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmploymentType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmploymentType");
        }
    }
}
