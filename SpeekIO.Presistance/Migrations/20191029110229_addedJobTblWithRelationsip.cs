using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class addedJobTblWithRelationsip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "Job",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MinWorkHours = table.Column<int>(nullable: true),
                    MaxWorkHours = table.Column<int>(nullable: true),
                    StatusId = table.Column<long>(nullable: false),
                    JobCategoryId = table.Column<long>(nullable: true),
                    EmploymentTypeId = table.Column<long>(nullable: true),
                    LanguageId = table.Column<long>(nullable: false),
                    QualificationId = table.Column<long>(nullable: true),
                    JobStatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_EmploymentType_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalSchema: "Job",
                        principalTable: "JobCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobStatus_JobStatusId",
                        column: x => x.JobStatusId,
                        principalTable: "JobStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalSchema: "Job",
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmploymentTypeId",
                schema: "Job",
                table: "Job",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Id",
                schema: "Job",
                table: "Job",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobCategoryId",
                schema: "Job",
                table: "Job",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobStatusId",
                schema: "Job",
                table: "Job",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_LanguageId",
                schema: "Job",
                table: "Job",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_QualificationId",
                schema: "Job",
                table: "Job",
                column: "QualificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job",
                schema: "Job");

            migrationBuilder.DropTable(
                name: "JobStatus");
        }
    }
}
