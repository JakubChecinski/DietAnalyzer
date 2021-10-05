using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Data.Migrations
{
    public partial class AddManyToManyRelationshipBetweenFoodAndMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietItem_Diets_DietId",
                table: "DietItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DietItem_FoodItems_FoodItemId",
                table: "DietItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DietItem_Measures_MeasureId",
                table: "DietItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietItem",
                table: "DietItem");

            migrationBuilder.RenameTable(
                name: "DietItem",
                newName: "DietItems");

            migrationBuilder.RenameIndex(
                name: "IX_DietItem_MeasureId",
                table: "DietItems",
                newName: "IX_DietItems_MeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_DietItem_FoodItemId",
                table: "DietItems",
                newName: "IX_DietItems_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DietItem_DietId",
                table: "DietItems",
                newName: "IX_DietItems_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietItems",
                table: "DietItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FoodMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMeasure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMeasure_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodMeasure_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeasure_FoodItemId",
                table: "FoodMeasure",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeasure_MeasureId",
                table: "FoodMeasure",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietItems_Diets_DietId",
                table: "DietItems",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DietItems_FoodItems_FoodItemId",
                table: "DietItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DietItems_Measures_MeasureId",
                table: "DietItems",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietItems_Diets_DietId",
                table: "DietItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DietItems_FoodItems_FoodItemId",
                table: "DietItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DietItems_Measures_MeasureId",
                table: "DietItems");

            migrationBuilder.DropTable(
                name: "FoodMeasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietItems",
                table: "DietItems");

            migrationBuilder.RenameTable(
                name: "DietItems",
                newName: "DietItem");

            migrationBuilder.RenameIndex(
                name: "IX_DietItems_MeasureId",
                table: "DietItem",
                newName: "IX_DietItem_MeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_DietItems_FoodItemId",
                table: "DietItem",
                newName: "IX_DietItem_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DietItems_DietId",
                table: "DietItem",
                newName: "IX_DietItem_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietItem",
                table: "DietItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DietItem_Diets_DietId",
                table: "DietItem",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DietItem_FoodItems_FoodItemId",
                table: "DietItem",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DietItem_Measures_MeasureId",
                table: "DietItem",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
