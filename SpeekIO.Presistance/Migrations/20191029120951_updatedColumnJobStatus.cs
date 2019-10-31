using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class updatedColumnJobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobStatus_JobStatusId",
                schema: "Job",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "Job",
                table: "Job");

            migrationBuilder.AlterColumn<long>(
                name: "JobStatusId",
                schema: "Job",
                table: "Job",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobStatus_JobStatusId",
                schema: "Job",
                table: "Job",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobStatus_JobStatusId",
                schema: "Job",
                table: "Job");

            migrationBuilder.AlterColumn<long>(
                name: "JobStatusId",
                schema: "Job",
                table: "Job",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                schema: "Job",
                table: "Job",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobStatus_JobStatusId",
                schema: "Job",
                table: "Job",
                column: "JobStatusId",
                principalTable: "JobStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
