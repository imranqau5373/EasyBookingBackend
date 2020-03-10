using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class changeFKKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CategoryStatusId",
                table: "CourtsDurations");

            migrationBuilder.AlterColumn<long>(
                name: "DurationStatusId",
                table: "CourtsDurations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations",
                column: "DurationStatusId",
                principalTable: "DurationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations");

            migrationBuilder.AlterColumn<long>(
                name: "DurationStatusId",
                table: "CourtsDurations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "CategoryStatusId",
                table: "CourtsDurations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations",
                column: "DurationStatusId",
                principalTable: "DurationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
