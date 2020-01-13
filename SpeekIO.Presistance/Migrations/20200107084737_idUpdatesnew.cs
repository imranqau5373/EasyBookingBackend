using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class idUpdatesnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "CourtsBookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourtId",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourtId",
                table: "CourtsBookings",
                nullable: true);
        }
    }
}
