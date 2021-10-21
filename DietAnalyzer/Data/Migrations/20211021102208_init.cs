using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    IsPubliclyKnown = table.Column<bool>(type: "bit", nullable: false),
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
                name: "RestrictionsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_RestrictionsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestrictionsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    NutrientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationResults_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionDiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_NutritionDiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionDiets_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionFoods",
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
                    table.PrimaryKey("PK_NutritionFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionFoods_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestrictionsFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RestrictionsFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestrictionsFoods_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietItems_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DietItems_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCurrentlyLinked = table.Column<bool>(type: "bit", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMeasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMeasures_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodMeasures_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "spinach", null },
                    { 2, "bananas", null },
                    { 3, "eggs", null },
                    { 4, "yogurt", null },
                    { 5, "chicken breast", null },
                    { 6, "salmon", null },
                    { 7, "bread (rye)", null },
                    { 8, "potatoes", null }
                });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Grams", "IsPubliclyKnown", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1f, true, "grams", null },
                    { 2, 135f, false, "large bananas", null },
                    { 3, 50f, false, "large eggs", null },
                    { 4, 35f, false, "slices", null }
                });

            migrationBuilder.InsertData(
                table: "FoodMeasures",
                columns: new[] { "Id", "FoodItemId", "IsCurrentlyLinked", "MeasureId" },
                values: new object[,]
                {
                    { 31, 7, true, 4 },
                    { 10, 2, true, 2 },
                    { 8, 8, true, 1 },
                    { 7, 7, true, 1 },
                    { 6, 6, true, 1 },
                    { 5, 5, true, 1 },
                    { 4, 4, true, 1 },
                    { 3, 3, true, 1 },
                    { 2, 2, true, 1 },
                    { 1, 1, true, 1 },
                    { 19, 3, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "NutritionFoods",
                columns: new[] { "Id", "CalciumPer100g", "CaloriesPer100g", "CarbohydratesPer100g", "CopperPer100g", "FatsPer100g", "FiberPer100g", "FoodItemId", "IronPer100g", "MagnesiumPer100g", "ManganesePer100g", "PhosphorusPer100g", "PotassiumPer100g", "ProteinsPer100g", "SaturatedFatPer100g", "SeleniumPer100g", "SodiumPer100g", "SugarPer100g", "VitaminAPer100g", "VitaminB12Per100g", "VitaminB1Per100g", "VitaminB2Per100g", "VitaminB3Per100g", "VitaminB6Per100g", "VitaminB9Per100g", "VitaminCPer100g", "VitaminDPer100g", "VitaminEPer100g", "VitaminKPer100g", "ZincPer100g" },
                values: new object[,]
                {
                    { 8, 1f, 86f, 20f, 8f, 0.1f, 1.8f, 8, 2f, 5f, 7f, 4f, 9f, 1.7f, 0f, 0f, 0f, 0.9f, 0f, 0f, 7f, 1f, 7f, 13f, 2f, 12f, 0f, 0f, 3f, 2f },
                    { 1, 3f, 23f, 3.6f, 2f, 0.4f, 2.2f, 1, 5f, 6f, 13f, 1f, 5f, 2.9f, 0.1f, 0f, 3f, 0.4f, 188f, 0f, 5f, 11f, 4f, 10f, 49f, 47f, 0f, 10f, 604f, 1f },
                    { 6, 1f, 206f, 0f, 2f, 12.3f, 0f, 6, 2f, 8f, 1f, 25f, 11f, 22.1f, 2.5f, 59f, 3f, 0f, 1f, 47f, 23f, 8f, 40f, 32f, 8f, 6f, 0f, 0f, 0f, 3f },
                    { 5, 1f, 79f, 0.2f, 2f, 0.4f, 0f, 5, 2f, 2f, 2f, 6f, 2f, 16.8f, 0.1f, 11f, 45f, 0.1f, 0f, 1f, 1f, 2f, 17f, 8f, 0f, 0f, 0f, 0f, 0f, 2f },
                    { 4, 12f, 61f, 4.7f, 0f, 3.3f, 0f, 4, 0f, 3f, 0f, 9f, 4f, 3.5f, 2.1f, 3f, 2f, 4.7f, 2f, 6f, 2f, 8f, 0f, 2f, 2f, 1f, 0f, 0f, 0f, 4f },
                    { 3, 5f, 155f, 1.1f, 1f, 10.6f, 0f, 3, 7f, 2f, 1f, 17f, 4f, 12.6f, 3.3f, 44f, 5f, 1.1f, 12f, 19f, 4f, 30f, 0f, 6f, 11f, 0f, 0f, 5f, 0f, 7f },
                    { 2, 1f, 89f, 22.8f, 4f, 0.3f, 2.6f, 2, 1f, 7f, 13f, 2f, 10f, 1.1f, 0.1f, 1f, 0f, 12.2f, 1f, 0f, 2f, 4f, 3f, 18f, 5f, 15f, 0f, 1f, 1f, 1f },
                    { 7, 7f, 258f, 48.3f, 9f, 3.3f, 5.8f, 7, 16f, 10f, 41f, 12f, 5f, 8.5f, 0.6f, 44f, 27f, 3.8f, 0f, 0f, 29f, 20f, 19f, 4f, 27f, 1f, 0f, 2f, 1f, 8f }
                });

            migrationBuilder.InsertData(
                table: "RestrictionsFoods",
                columns: new[] { "Id", "DairyIntolerant", "Diabetes", "FoodItemId", "GlutenIntolerant", "HeartProblems", "Keto", "KidneyProblems", "Paleo", "Pescetarian", "Vegan", "Vegetarian" },
                values: new object[,]
                {
                    { 6, true, true, 6, true, true, true, true, true, true, false, false },
                    { 8, true, false, 8, true, true, false, false, false, true, true, true },
                    { 5, false, true, 5, true, true, true, true, true, false, false, false },
                    { 4, false, true, 4, true, true, true, true, false, true, false, true },
                    { 3, true, true, 3, true, false, true, true, true, true, false, true },
                    { 2, true, true, 2, true, true, false, false, true, true, true, true },
                    { 1, true, true, 1, true, true, true, false, true, true, true, true },
                    { 7, true, true, 7, false, true, false, false, false, true, true, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DietItems_DietId",
                table: "DietItems",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_DietItems_FoodItemId",
                table: "DietItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DietItems_MeasureId",
                table: "DietItems",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationResults_DietId",
                table: "EvaluationResults",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeasures_FoodItemId",
                table: "FoodMeasures",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeasures_MeasureId",
                table: "FoodMeasures",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_UserId",
                table: "Measures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionDiets_DietId",
                table: "NutritionDiets",
                column: "DietId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionFoods_FoodItemId",
                table: "NutritionFoods",
                column: "FoodItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestrictionsFoods_FoodItemId",
                table: "RestrictionsFoods",
                column: "FoodItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestrictionsUsers_UserId",
                table: "RestrictionsUsers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DietItems");

            migrationBuilder.DropTable(
                name: "EvaluationResults");

            migrationBuilder.DropTable(
                name: "FoodMeasures");

            migrationBuilder.DropTable(
                name: "NutritionDiets");

            migrationBuilder.DropTable(
                name: "NutritionFoods");

            migrationBuilder.DropTable(
                name: "RestrictionsFoods");

            migrationBuilder.DropTable(
                name: "RestrictionsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
