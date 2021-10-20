using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class AddValueFieldsToEvaluationResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "EvaluationResults",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValueAlternative",
                table: "EvaluationResults",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "EvaluationResults");

            migrationBuilder.DropColumn(
                name: "ValueAlternative",
                table: "EvaluationResults");
        }
    }
}
