using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class ReplaceFoodDietRecommendationWithString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodDietRecommendations");

            migrationBuilder.AddColumn<string>(
                name: "Recommendations",
                table: "Diets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recommendations",
                table: "Diets");

            migrationBuilder.CreateTable(
                name: "FoodDietRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDietRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDietRecommendations_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodDietRecommendations_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodDietRecommendations_DietId",
                table: "FoodDietRecommendations",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDietRecommendations_FoodItemId",
                table: "FoodDietRecommendations",
                column: "FoodItemId");
        }
    }
}
