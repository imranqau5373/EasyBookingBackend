using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class AddedColumnsProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Portfolio",
                table: "Profile");
        }
    }
}
