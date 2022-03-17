using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestFood.Infrastructure.Data.Migrations
{
    public partial class RemovedIngredientPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Ingredients",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
