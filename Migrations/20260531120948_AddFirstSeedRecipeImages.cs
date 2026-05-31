using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstSeedRecipeImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/dishes/seeded/oatmeal-with-apple.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/dishes/seeded/chicken-vegetable-soup.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/dishes/seeded/baked-fish-with-vegetables.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/dishes/seeded/yogurt-with-berries.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");
        }
    }
}
