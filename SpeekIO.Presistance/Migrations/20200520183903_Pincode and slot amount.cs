using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class Pincodeandslotamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PinCode",
                table: "CourtsBookings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SlotAmount",
                table: "CourtsBookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "SlotAmount",
                table: "CourtsBookings");
        }
    }
}
