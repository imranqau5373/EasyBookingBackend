using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class Durationstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryStatusId",
                table: "CourtsDurations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DurationStatusId",
                table: "CourtsDurations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DurationStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourtsDurations_DurationStatusId",
                table: "CourtsDurations",
                column: "DurationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations",
                column: "DurationStatusId",
                principalTable: "DurationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtsDurations_DurationStatus_DurationStatusId",
                table: "CourtsDurations");

            migrationBuilder.DropTable(
                name: "DurationStatus");

            migrationBuilder.DropIndex(
                name: "IX_CourtsDurations_DurationStatusId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "CategoryStatusId",
                table: "CourtsDurations");

            migrationBuilder.DropColumn(
                name: "DurationStatusId",
                table: "CourtsDurations");
        }
    }
}
