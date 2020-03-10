using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class CourtDurationCourtBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourtsDurationsId",
                table: "CourtsBookings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DurationId",
                table: "CourtsBookings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CourtsBookings_CourtsDurationsId",
                table: "CourtsBookings",
                column: "CourtsDurationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsBookings_CourtsDurations_CourtsDurationsId",
                table: "CourtsBookings",
                column: "CourtsDurationsId",
                principalTable: "CourtsDurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtsBookings_CourtsDurations_CourtsDurationsId",
                table: "CourtsBookings");

            migrationBuilder.DropIndex(
                name: "IX_CourtsBookings_CourtsDurationsId",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "CourtsDurationsId",
                table: "CourtsBookings");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "CourtsBookings");
        }
    }
}
