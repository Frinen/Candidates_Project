using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidates.Models.Migrations
{
    public partial class ChangeOptionKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Options_CanWorkRemotly",
                table: "Options");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Options_CanWorkRemotly",
                table: "Options",
                column: "CanWorkRemotly");
        }
    }
}
