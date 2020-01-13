using Microsoft.EntityFrameworkCore.Migrations;
using System;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class removedCourtDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourtDuration",
                table: "CourtsDurations");

            migrationBuilder.AlterColumn<int>(
                name: "SlotDuration",
                table: "CourtsDurations",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "SlotDuration",
                table: "CourtsDurations",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CourtDuration",
                table: "CourtsDurations",
                nullable: true);
        }
    }
}
