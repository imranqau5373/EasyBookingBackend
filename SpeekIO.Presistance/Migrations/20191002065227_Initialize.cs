using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.CreateTable(
                name: "Attachment",
                schema: "Common",
                columns: table => new
                {
                    AttachmentGuid = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentGuid);
                    table.UniqueConstraint("AK_Attachment_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Id",
                schema: "Common",
                table: "Attachment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment",
                schema: "Common");
        }
    }
}
