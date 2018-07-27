using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidates.Models.Migrations
{
    public partial class ChangeOptionKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_ID",
                table: "Options");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Options_CanWorkRemotly",
                table: "Options",
                column: "CanWorkRemotly");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Options_CanWorkRemotly",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "CanWorkRemotly");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ID",
                table: "Options",
                column: "ID",
                unique: true);
        }
    }
}
