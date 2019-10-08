using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class LinksBetweenAppUserProfileCompanyAndSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                schema: "Communication",
                table: "Participant",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduledStartTime",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduledEndTime",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                column: "ConferenceSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ProfileId",
                schema: "Communication",
                table: "Participant",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSession_CompanyId",
                schema: "Communication",
                table: "ConferenceSession",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceSession_CreatedById",
                schema: "Communication",
                table: "ConferenceSession",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSession_Company_CompanyId",
                schema: "Communication",
                table: "ConferenceSession",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceSession_Profile_CreatedById",
                schema: "Communication",
                table: "ConferenceSession",
                column: "CreatedById",
                principalSchema: "Portfolio",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                column: "ConferenceSessionId",
                principalSchema: "Communication",
                principalTable: "ConferenceSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Profile_ProfileId",
                schema: "Communication",
                table: "Participant",
                column: "ProfileId",
                principalSchema: "Portfolio",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSession_Company_CompanyId",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceSession_Profile_CreatedById",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Profile_ProfileId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_ConferenceSessionId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_ProfileId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceSession_CompanyId",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceSession_CreatedById",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropColumn(
                name: "ConferenceSessionId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Communication",
                table: "ConferenceSession");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduledStartTime",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduledEndTime",
                schema: "Communication",
                table: "ConferenceSession",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
