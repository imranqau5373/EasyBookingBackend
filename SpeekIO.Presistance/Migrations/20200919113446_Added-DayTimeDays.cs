using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyBooking.Presistence.Migrations
{
    public partial class AddedDayTimeDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "DayTimeSchedules",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayTimeDays",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DayTimeScheduleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTimeDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayTimeDays_DayTimeSchedules_DayTimeScheduleId",
                        column: x => x.DayTimeScheduleId,
                        principalTable: "DayTimeSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTimeSchedules_CompanyId",
                table: "DayTimeSchedules",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTimeDays_DayTimeScheduleId",
                table: "DayTimeDays",
                column: "DayTimeScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTimeSchedules_Company_CompanyId",
                table: "DayTimeSchedules",
                column: "CompanyId",
                principalSchema: "Portfolio",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTimeSchedules_Company_CompanyId",
                table: "DayTimeSchedules");

            migrationBuilder.DropTable(
                name: "DayTimeDays");

            migrationBuilder.DropIndex(
                name: "IX_DayTimeSchedules_CompanyId",
                table: "DayTimeSchedules");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "DayTimeSchedules");
        }
    }
}
