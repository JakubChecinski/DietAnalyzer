using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DietAnalyzer.Migrations
{
    public partial class Init : Migration
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
                    ImageFromApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFromUser = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    IsKnownUniversally = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "Id", "ImageFromApp", "ImageFromUser", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "/images/spinach.png", null, "spinach", null },
                    { 20, "/images/mushrooms.png", null, "mushrooms", null },
                    { 19, "/images/milk.png", null, "milk", null },
                    { 18, "/images/kidney_beans.png", null, "kidney beans", null },
                    { 17, "/images/pasta.png", null, "pasta", null },
                    { 16, "/images/onion.png", null, "onions", null },
                    { 14, "/images/olives.png", null, "olives", null },
                    { 13, "/images/steak.png", null, "pork steak", null },
                    { 12, "/images/sardines.png", null, "sardines", null },
                    { 11, "/images/bread_wheat.png", null, "bread (wheat)", null },
                    { 15, "/images/tomato.png", null, "tomatoes", null },
                    { 9, "/images/cheese.png", null, "cheese", null },
                    { 8, "/images/potatoes.png", null, "potatoes", null },
                    { 7, "/images/bread_rye.png", null, "bread (rye)", null },
                    { 6, "/images/salmon.png", null, "salmon", null },
                    { 5, "/images/chicken_breast.png", null, "chicken breast", null },
                    { 4, "/images/yogurt.png", null, "yogurt", null },
                    { 3, "/images/eggs.png", null, "eggs", null },
                    { 2, "/images/bananas.png", null, "bananas", null },
                    { 10, "/images/chocolate.png", null, "chocolate", null }
                });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Grams", "IsKnownUniversally", "Name", "UserId" },
                values: new object[,]
                {
                    { 13, 12f, false, "medium sardines", null },
                    { 12, 35f, false, "slices", null },
                    { 11, 50f, false, "large eggs", null },
                    { 10, 135f, false, "large bananas", null },
                    { 1, 1f, true, "grams", null },
                    { 3, 5f, true, "teaspoons", null },
                    { 2, 15f, true, "tablespoons", null },
                    { 14, 170f, false, "medium tomatoes", null },
                    { 4, 250f, true, "cups", null },
                    { 15, 110f, false, "medium onions", null }
                });

            migrationBuilder.InsertData(
                table: "FoodMeasures",
                columns: new[] { "Id", "FoodItemId", "IsCurrentlyLinked", "MeasureId" },
                values: new object[,]
                {
                    { 104, 4, true, 2 },
                    { 213, 13, true, 3 },
                    { 212, 12, true, 3 },
                    { 211, 11, true, 3 },
                    { 210, 10, true, 3 },
                    { 209, 9, true, 3 },
                    { 208, 8, true, 3 },
                    { 207, 7, true, 3 },
                    { 206, 6, true, 3 },
                    { 205, 5, true, 3 },
                    { 204, 4, true, 3 },
                    { 203, 3, true, 3 },
                    { 202, 2, true, 3 },
                    { 201, 1, true, 3 },
                    { 214, 14, true, 3 },
                    { 120, 20, true, 2 },
                    { 118, 18, true, 2 },
                    { 117, 17, true, 2 },
                    { 116, 16, true, 2 },
                    { 115, 15, true, 2 },
                    { 114, 14, true, 2 },
                    { 113, 13, true, 2 },
                    { 112, 12, true, 2 },
                    { 111, 11, true, 2 },
                    { 110, 10, true, 2 },
                    { 109, 9, true, 2 },
                    { 108, 8, true, 2 },
                    { 107, 7, true, 2 },
                    { 106, 6, true, 2 },
                    { 119, 19, true, 2 },
                    { 105, 5, true, 2 },
                    { 215, 15, true, 3 },
                    { 217, 17, true, 3 },
                    { 1004, 12, true, 13 },
                    { 1003, 11, true, 12 },
                    { 1002, 7, true, 12 },
                    { 1001, 3, true, 11 },
                    { 1000, 2, true, 10 },
                    { 320, 20, true, 4 },
                    { 319, 19, true, 4 },
                    { 318, 18, true, 4 },
                    { 317, 17, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "FoodMeasures",
                columns: new[] { "Id", "FoodItemId", "IsCurrentlyLinked", "MeasureId" },
                values: new object[,]
                {
                    { 316, 16, true, 4 },
                    { 315, 15, true, 4 },
                    { 314, 14, true, 4 },
                    { 313, 13, true, 4 },
                    { 216, 16, true, 3 },
                    { 312, 12, true, 4 },
                    { 310, 10, true, 4 },
                    { 309, 9, true, 4 },
                    { 308, 8, true, 4 },
                    { 307, 7, true, 4 },
                    { 306, 6, true, 4 },
                    { 305, 5, true, 4 },
                    { 304, 4, true, 4 },
                    { 303, 3, true, 4 },
                    { 302, 2, true, 4 },
                    { 301, 1, true, 4 },
                    { 220, 20, true, 3 },
                    { 219, 19, true, 3 },
                    { 218, 18, true, 3 },
                    { 311, 11, true, 4 },
                    { 1005, 15, true, 14 },
                    { 1006, 16, true, 15 },
                    { 102, 2, true, 2 },
                    { 103, 3, true, 2 },
                    { 1, 1, true, 1 },
                    { 2, 2, true, 1 },
                    { 3, 3, true, 1 },
                    { 4, 4, true, 1 },
                    { 6, 6, true, 1 },
                    { 7, 7, true, 1 },
                    { 8, 8, true, 1 },
                    { 9, 9, true, 1 },
                    { 10, 10, true, 1 },
                    { 5, 5, true, 1 },
                    { 12, 12, true, 1 },
                    { 13, 13, true, 1 },
                    { 14, 14, true, 1 },
                    { 15, 15, true, 1 },
                    { 16, 16, true, 1 },
                    { 17, 17, true, 1 },
                    { 18, 18, true, 1 },
                    { 19, 19, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "FoodMeasures",
                columns: new[] { "Id", "FoodItemId", "IsCurrentlyLinked", "MeasureId" },
                values: new object[,]
                {
                    { 20, 20, true, 1 },
                    { 101, 1, true, 2 },
                    { 11, 11, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "NutritionFoods",
                columns: new[] { "Id", "CalciumPer100g", "CaloriesPer100g", "CarbohydratesPer100g", "CopperPer100g", "FatsPer100g", "FiberPer100g", "FoodItemId", "IronPer100g", "MagnesiumPer100g", "ManganesePer100g", "PhosphorusPer100g", "PotassiumPer100g", "ProteinsPer100g", "SaturatedFatPer100g", "SeleniumPer100g", "SodiumPer100g", "SugarPer100g", "VitaminAPer100g", "VitaminB12Per100g", "VitaminB1Per100g", "VitaminB2Per100g", "VitaminB3Per100g", "VitaminB6Per100g", "VitaminB9Per100g", "VitaminCPer100g", "VitaminDPer100g", "VitaminEPer100g", "VitaminKPer100g", "ZincPer100g" },
                values: new object[,]
                {
                    { 11, 14f, 266f, 47.5f, 8f, 3.6f, 3.6f, 11, 19f, 12f, 56f, 15f, 5f, 10.9f, 0.8f, 41f, 22f, 5.8f, 0f, 0f, 25f, 18f, 26f, 6f, 21f, 0f, 0f, 1f, 6f, 8f },
                    { 10, 3f, 479f, 63.1f, 35f, 30f, 5.9f, 10, 17f, 29f, 40f, 13f, 10f, 4.2f, 17.7f, 6f, 0f, 54.5f, 0f, 0f, 4f, 5f, 2f, 2f, 3f, 0f, 0f, 1f, 7f, 11f },
                    { 9, 70f, 356f, 2.2f, 2f, 27.4f, 0f, 9, 1f, 7f, 1f, 55f, 3f, 24.9f, 17.6f, 21f, 34f, 2.2f, 11f, 26f, 3f, 20f, 0f, 4f, 5f, 0f, 0f, 1f, 2f, 26f },
                    { 8, 1f, 86f, 20f, 8f, 0.1f, 1.8f, 8, 2f, 5f, 7f, 4f, 9f, 1.7f, 0f, 0f, 0f, 0.9f, 0f, 0f, 7f, 1f, 7f, 13f, 2f, 12f, 0f, 0f, 3f, 2f },
                    { 3, 5f, 155f, 1.1f, 1f, 10.6f, 0f, 3, 7f, 2f, 1f, 17f, 4f, 12.6f, 3.3f, 44f, 5f, 1.1f, 12f, 19f, 4f, 30f, 0f, 6f, 11f, 0f, 0f, 5f, 0f, 7f },
                    { 6, 1f, 206f, 0f, 2f, 12.3f, 0f, 6, 2f, 8f, 1f, 25f, 11f, 22.1f, 2.5f, 59f, 3f, 0f, 1f, 47f, 23f, 8f, 40f, 32f, 8f, 6f, 0f, 0f, 0f, 3f },
                    { 5, 1f, 79f, 0.2f, 2f, 0.4f, 0f, 5, 2f, 2f, 2f, 6f, 2f, 16.8f, 0.1f, 11f, 45f, 0.1f, 0f, 1f, 1f, 2f, 17f, 8f, 0f, 0f, 0f, 0f, 0f, 2f },
                    { 4, 12f, 61f, 4.7f, 0f, 3.3f, 0f, 4, 0f, 3f, 0f, 9f, 4f, 3.5f, 2.1f, 3f, 2f, 4.7f, 2f, 6f, 2f, 8f, 0f, 2f, 2f, 1f, 0f, 0f, 0f, 4f },
                    { 2, 1f, 89f, 22.8f, 4f, 0.3f, 2.6f, 2, 1f, 7f, 13f, 2f, 10f, 1.1f, 0.1f, 1f, 0f, 12.2f, 1f, 0f, 2f, 4f, 3f, 18f, 5f, 15f, 0f, 1f, 1f, 1f },
                    { 12, 38f, 208f, 0f, 9f, 11.5f, 0f, 12, 16f, 10f, 5f, 49f, 11f, 24.6f, 1.5f, 75f, 21f, 0f, 2f, 149f, 5f, 13f, 26f, 8f, 3f, 0f, 68f, 10f, 3f, 9f },
                    { 7, 7f, 258f, 48.3f, 9f, 3.3f, 5.8f, 7, 16f, 10f, 41f, 12f, 5f, 8.5f, 0.6f, 44f, 27f, 3.8f, 0f, 0f, 29f, 20f, 19f, 4f, 27f, 1f, 0f, 2f, 1f, 8f },
                    { 13, 3f, 227f, 0f, 10f, 12.1f, 0f, 13, 10f, 5f, 1f, 23f, 11f, 27.6f, 4.6f, 65f, 6f, 0f, 0f, 16f, 28f, 22f, 18f, 24f, 0f, 0f, 0f, 1f, 0f, 32f },
                    { 16, 2f, 40f, 9.3f, 2f, 0.1f, 1.7f, 16, 1f, 2f, 6f, 3f, 4f, 1.1f, 0f, 1f, 0f, 4.2f, 0f, 0f, 3f, 2f, 1f, 6f, 5f, 12f, 0f, 0f, 0f, 1f },
                    { 18, 4f, 225f, 22.8f, 12f, 0.5f, 6.4f, 18, 12f, 10f, 22f, 14f, 12f, 8.7f, 0.1f, 2f, 0f, 0.3f, 0f, 0f, 11f, 3f, 3f, 6f, 33f, 2f, 0f, 0f, 10f, 7f },
                    { 20, 0f, 35f, 4.9f, 25f, 0.7f, 2.2f, 20, 3f, 4f, 4f, 15f, 15f, 4.3f, 0.1f, 25f, 0f, 0f, 0f, 0f, 6f, 28f, 30f, 4f, 5f, 0f, 0f, 0f, 0f, 5f },
                    { 19, 11f, 60f, 5.3f, 1f, 3.3f, 0f, 19, 0f, 2f, 0f, 9f, 4f, 3.2f, 1.9f, 5f, 2f, 0f, 2f, 7f, 3f, 11f, 1f, 2f, 1f, 0f, 10f, 0f, 0f, 3f },
                    { 14, 5f, 145f, 3.8f, 6f, 15.3f, 3.3f, 14, 3f, 3f, 0f, 0f, 1f, 1f, 2f, 1f, 65f, 0.5f, 8f, 0f, 1f, 0f, 1f, 2f, 1f, 0f, 0f, 19f, 2f, 0f },
                    { 17, 1f, 131f, 24.9f, 5f, 1.1f, 0f, 17, 6f, 5f, 11f, 6f, 1f, 5.2f, 0.2f, 0f, 0f, 0f, 0f, 2f, 14f, 9f, 5f, 2f, 16f, 0f, 0f, 0f, 0f, 4f },
                    { 1, 3f, 23f, 3.6f, 2f, 0.4f, 2.2f, 1, 5f, 6f, 13f, 1f, 5f, 2.9f, 0.1f, 0f, 3f, 0.4f, 188f, 0f, 5f, 11f, 4f, 10f, 49f, 47f, 0f, 10f, 604f, 1f },
                    { 15, 1f, 18f, 3.9f, 3f, 0.2f, 1.2f, 15, 1f, 3f, 6f, 2f, 7f, 0.9f, 0f, 0f, 0f, 2.6f, 17f, 0f, 2f, 1f, 3f, 4f, 4f, 21f, 0f, 3f, 10f, 1f }
                });

            migrationBuilder.InsertData(
                table: "RestrictionsFoods",
                columns: new[] { "Id", "DairyIntolerant", "Diabetes", "FoodItemId", "GlutenIntolerant", "HeartProblems", "Keto", "KidneyProblems", "Paleo", "Pescetarian", "Vegan", "Vegetarian" },
                values: new object[,]
                {
                    { 10, false, false, 10, true, false, false, false, false, true, false, true },
                    { 1, true, true, 1, true, true, true, false, true, true, true, true },
                    { 20, true, true, 20, true, true, true, false, true, true, true, true },
                    { 2, true, true, 2, true, true, false, false, true, true, true, true },
                    { 14, true, true, 14, true, true, true, true, true, true, true, true },
                    { 3, true, true, 3, true, false, true, true, true, true, false, true },
                    { 19, false, true, 19, true, false, false, false, false, true, false, true },
                    { 4, false, true, 4, true, true, true, true, false, true, false, true },
                    { 12, true, true, 12, true, true, true, true, true, true, false, false },
                    { 5, false, true, 5, true, true, true, true, true, false, false, false },
                    { 18, true, true, 18, true, true, false, false, false, true, true, true },
                    { 6, true, true, 6, true, true, true, true, true, true, false, false },
                    { 7, true, true, 7, false, true, false, false, false, true, true, true },
                    { 17, true, false, 17, false, false, false, true, false, true, true, true },
                    { 8, true, false, 8, true, true, false, false, false, true, true, true },
                    { 11, true, false, 11, false, false, false, true, false, true, true, true },
                    { 9, false, true, 9, true, false, true, true, false, true, false, true },
                    { 16, true, true, 16, true, true, false, true, true, true, true, true },
                    { 15, true, true, 15, true, true, true, false, true, true, true, true }
                });

            migrationBuilder.InsertData(
                table: "RestrictionsFoods",
                columns: new[] { "Id", "DairyIntolerant", "Diabetes", "FoodItemId", "GlutenIntolerant", "HeartProblems", "Keto", "KidneyProblems", "Paleo", "Pescetarian", "Vegan", "Vegetarian" },
                values: new object[] { 13, true, true, 13, true, false, true, false, true, false, false, false });

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
