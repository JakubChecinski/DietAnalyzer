using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Data.Migrations
{
    public partial class AddNutritionInfoToDiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionInfos_FoodItems_FoodItemId",
                table: "NutritionInfos");

            migrationBuilder.DropIndex(
                name: "IX_NutritionInfos_FoodItemId",
                table: "NutritionInfos");

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "NutritionInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "NutritionInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionInfos_DietId",
                table: "NutritionInfos",
                column: "DietId",
                unique: true,
                filter: "[DietId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionInfos_FoodItemId",
                table: "NutritionInfos",
                column: "FoodItemId",
                unique: true,
                filter: "[FoodItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionInfos_Diets_DietId",
                table: "NutritionInfos",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionInfos_FoodItems_FoodItemId",
                table: "NutritionInfos",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionInfos_Diets_DietId",
                table: "NutritionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NutritionInfos_FoodItems_FoodItemId",
                table: "NutritionInfos");

            migrationBuilder.DropIndex(
                name: "IX_NutritionInfos_DietId",
                table: "NutritionInfos");

            migrationBuilder.DropIndex(
                name: "IX_NutritionInfos_FoodItemId",
                table: "NutritionInfos");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "NutritionInfos");

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "NutritionInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionInfos_FoodItemId",
                table: "NutritionInfos",
                column: "FoodItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionInfos_FoodItems_FoodItemId",
                table: "NutritionInfos",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
