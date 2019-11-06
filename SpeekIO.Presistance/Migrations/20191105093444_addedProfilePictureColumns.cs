using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class addedProfilePictureColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureThumbnailUrl",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                schema: "Portfolio",
                table: "Profile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureThumbnailUrl",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                schema: "Portfolio",
                table: "Profile");
        }
    }
}
