using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class IsCancelled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "CourtsBookings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "CourtsBookings");
        }
    }
}
