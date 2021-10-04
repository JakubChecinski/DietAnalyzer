using Microsoft.EntityFrameworkCore.Migrations;

namespace DietAnalyzer.Data.Migrations
{
    public partial class AddQuantityToDietItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "DietItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "DietItem");
        }
    }
}
