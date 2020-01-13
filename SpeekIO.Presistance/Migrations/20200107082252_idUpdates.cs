using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class idUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourtDuration",
                table: "CourtsBookings");

            migrationBuilder.RenameColumn(
                name: "CourtStartTime",
                table: "CourtsBookings",
                newName: "BookingStartTime");

            migrationBuilder.RenameColumn(
                name: "CourtEndTime",
                table: "CourtsBookings",
                newName: "BookingEndTime");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CourtsBookings",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourtDuration",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourtEndTime",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourtId",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourtStartTime",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourtsId",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourtsId",
                table: "CourtsBookings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "CourtsBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailed",
                table: "CourtsBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "CourtsBookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_CompanyId",
                table: "Sports",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtsDurations_CourtsId",
                table: "CourtsDurations",
                column: "CourtsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtsBookings_CourtsId",
                table: "CourtsBookings",
                column: "CourtsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtsBookings_ProfileId",
                table: "CourtsBookings",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CompanyId",
                table: "Courts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_SportsId",
                table: "Courts",
                column: "SportsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Company_CompanyId",
                table: "Courts",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Sports_SportsId",
                table: "Courts",
                column: "SportsId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsBookings_Courts_CourtsId",
                table: "CourtsBookings",
                column: "CourtsId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsBookings_Profile_ProfileId",
                table: "CourtsBookings",
                column: "ProfileId",
                principalSchema: "Portfolio",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsDurations_Courts_CourtsId",
                table: "CourtsDurations",
                column: "CourtsId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Company_CompanyId",
                table: "Sports",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Company_CompanyId",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Sports_SportsId",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtsBookings_Courts_CourtsId",
                table: "CourtsBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtsBookings_Profile_ProfileId",
                table: "CourtsBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtsDurations_Courts_CourtsId",
                table: "CourtsDurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Company_CompanyId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_CompanyId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_CourtsDurations_CourtsId",
                table: "CourtsDurations");

            migrationBuilder.DropIndex(
                name: "IX_CourtsBookings_CourtsId",
                table: "CourtsBookings");

            migrationBuilder.DropIndex(
                name: "IX_CourtsBookings_ProfileId",
                table: "CourtsBookings");

            migrationBuilder.DropIndex(
                name: "IX_Courts_CompanyId",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Courts_SportsId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "CourtDuration",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtEndTime",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtStartTime",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtsId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtsId",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "IsEmailed",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "CourtsBookings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CourtsBookings",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "BookingStartTime",
                table: "CourtsBookings",
                newName: "CourtStartTime");

            migrationBuilder.RenameColumn(
                name: "BookingEndTime",
                table: "CourtsBookings",
                newName: "CourtEndTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourtDuration",
                table: "CourtsBookings",
                nullable: true);
        }
    }
}
