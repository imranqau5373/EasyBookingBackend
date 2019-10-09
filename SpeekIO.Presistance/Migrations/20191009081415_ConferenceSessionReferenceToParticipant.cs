using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeekIO.Presistence.Migrations
{
    public partial class ConferenceSessionReferenceToParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.AlterColumn<long>(
                name: "ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                column: "ConferenceSessionId",
                principalSchema: "Communication",
                principalTable: "ConferenceSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant");

            migrationBuilder.AlterColumn<long>(
                name: "ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_ConferenceSession_ConferenceSessionId",
                schema: "Communication",
                table: "Participant",
                column: "ConferenceSessionId",
                principalSchema: "Communication",
                principalTable: "ConferenceSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
