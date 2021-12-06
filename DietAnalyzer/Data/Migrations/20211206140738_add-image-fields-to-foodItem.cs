using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Migrations
{
    public partial class addimagefieldstofoodItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFromApp",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFromUser",
                table: "FoodItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageFromApp",
                value: "/images/spinach.png");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageFromApp",
                value: "/images/eggs.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFromApp",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ImageFromUser",
                table: "FoodItems");
        }
    }
}
