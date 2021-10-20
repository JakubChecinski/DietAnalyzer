using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class AddUnitToEvaluationResultClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "EvaluationResults",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "EvaluationResults");
        }
    }
}
