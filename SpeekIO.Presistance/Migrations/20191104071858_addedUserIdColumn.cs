using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class addedUserIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ApplicationUser_UserId",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ApplicationUser_UserId",
                schema: "Portfolio",
                table: "Profile",
                column: "UserId",
                principalSchema: "User",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ApplicationUser_UserId",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Portfolio",
                table: "Profile",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ApplicationUser_UserId",
                schema: "Portfolio",
                table: "Profile",
                column: "UserId",
                principalSchema: "User",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
