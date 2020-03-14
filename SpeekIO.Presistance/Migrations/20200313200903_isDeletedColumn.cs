using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class isDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portfolio",
                table: "Company",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sports",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DurationStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourtsDurations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourtsBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DurationStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courts");
        }
    }
}
