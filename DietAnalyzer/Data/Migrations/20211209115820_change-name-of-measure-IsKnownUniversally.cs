using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class changenameofmeasureIsKnownUniversally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPubliclyKnown",
                table: "Measures",
                newName: "IsKnownUniversally");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsKnownUniversally",
                table: "Measures",
                newName: "IsPubliclyKnown");
        }
    }
}
