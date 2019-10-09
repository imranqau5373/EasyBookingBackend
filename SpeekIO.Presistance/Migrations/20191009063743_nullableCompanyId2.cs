using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class nullableCompanyId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Company_CompanyId",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                schema: "Portfolio",
                table: "Profile",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Company_CompanyId",
                schema: "Portfolio",
                table: "Profile",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Company_CompanyId",
                schema: "Portfolio",
                table: "Profile");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                schema: "Portfolio",
                table: "Profile",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Company_CompanyId",
                schema: "Portfolio",
                table: "Profile",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
