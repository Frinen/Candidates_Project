using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidates.Models.Migrations
{
    public partial class ChangeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Candidates_CandidateID",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "Options",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "Candidates",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "CanWorkRemotly");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ID",
                table: "Options",
                column: "ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Candidates_ID",
                table: "Options",
                column: "ID",
                principalTable: "Candidates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Candidates_ID",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_ID",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Options",
                newName: "CandidateID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Candidates",
                newName: "CandidateID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "CandidateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Candidates_CandidateID",
                table: "Options",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "CandidateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
