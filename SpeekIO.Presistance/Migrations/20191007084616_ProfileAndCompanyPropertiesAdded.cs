using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class ProfileAndCompanyPropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Portfolio",
                table: "Profile",
                newName: "Timezone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OptInNewsletter",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Portfolio",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDomainPrefix",
                schema: "Portfolio",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "Portfolio",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "OptInNewsletter",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SubDomainPrefix",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "Portfolio",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "Timezone",
                schema: "Portfolio",
                table: "Profile",
                newName: "FirstName");
        }
    }
}
