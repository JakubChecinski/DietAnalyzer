using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Grams = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDietRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    CaloriesPer100g = table.Column<float>(type: "real", nullable: true),
                    FiberPer100g = table.Column<float>(type: "real", nullable: true),
                    SugarPer100g = table.Column<float>(type: "real", nullable: true),
                    CarbohydratesPer100g = table.Column<float>(type: "real", nullable: true),
                    SaturatedFatPer100g = table.Column<float>(type: "real", nullable: true),
                    FatsPer100g = table.Column<float>(type: "real", nullable: true),
                    ProteinsPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminAPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminCPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminDPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminEPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminKPer100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB1Per100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB2Per100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB3Per100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB6Per100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB9Per100g = table.Column<float>(type: "real", nullable: true),
                    VitaminB12Per100g = table.Column<float>(type: "real", nullable: true),
                    CalciumPer100g = table.Column<float>(type: "real", nullable: true),
                    IronPer100g = table.Column<float>(type: "real", nullable: true),
                    MagnesiumPer100g = table.Column<float>(type: "real", nullable: true),
                    PhosphorusPer100g = table.Column<float>(type: "real", nullable: true),
                    PotassiumPer100g = table.Column<float>(type: "real", nullable: true),
                    SodiumPer100g = table.Column<float>(type: "real", nullable: true),
                    ZincPer100g = table.Column<float>(type: "real", nullable: true),
                    CopperPer100g = table.Column<float>(type: "real", nullable: true),
                    ManganesePer100g = table.Column<float>(type: "real", nullable: true),
                    SeleniumPer100g = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionInfos_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestrictionsInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Pescetarian = table.Column<bool>(type: "bit", nullable: false),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: false),
                    DairyIntolerant = table.Column<bool>(type: "bit", nullable: false),
                    Vegan = table.Column<bool>(type: "bit", nullable: false),
                    GlutenIntolerant = table.Column<bool>(type: "bit", nullable: false),
                    Paleo = table.Column<bool>(type: "bit", nullable: false),
                    Keto = table.Column<bool>(type: "bit", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    HeartProblems = table.Column<bool>(type: "bit", nullable: false),
                    KidneyProblems = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestrictionsInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestrictionsInfos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestrictionsInfos_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DietItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietItem_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DietItem_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DietItem_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietItem_DietId",
                table: "DietItem",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_DietItem_FoodItemId",
                table: "DietItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DietItem_MeasureId",
                table: "DietItem",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDietRecommendations_DietId",
                table: "FoodDietRecommendations",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDietRecommendations_FoodItemId",
                table: "FoodDietRecommendations",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_UserId",
                table: "Measures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionInfos_FoodItemId",
                table: "NutritionInfos",
                column: "FoodItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestrictionsInfos_FoodItemId",
                table: "RestrictionsInfos",
                column: "FoodItemId",
                unique: true,
                filter: "[FoodItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RestrictionsInfos_UserId",
                table: "RestrictionsInfos",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietItem");

            migrationBuilder.DropTable(
                name: "FoodDietRecommendations");

            migrationBuilder.DropTable(
                name: "NutritionInfos");

            migrationBuilder.DropTable(
                name: "RestrictionsInfos");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
