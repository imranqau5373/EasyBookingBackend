using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class AddTemplateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionTemplateName",
                schema: "Question",
                table: "QuestionType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTemplateName",
                schema: "Question",
                table: "QuestionType");
        }
    }
}
