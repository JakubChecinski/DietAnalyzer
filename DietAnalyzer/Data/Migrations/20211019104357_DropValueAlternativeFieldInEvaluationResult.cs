using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class DropValueAlternativeFieldInEvaluationResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueAlternative",
                table: "EvaluationResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValueAlternative",
                table: "EvaluationResults",
                type: "real",
                nullable: true);
        }
    }
}
