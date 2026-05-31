using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class AddAllSeedRecipeImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/dishes/seeded/cottage-cheese-casserole.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/dishes/seeded/buckwheat-with-turkey.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/dishes/seeded/vegetable-bean-stew.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/dishes/seeded/chicken-sandwich.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/images/dishes/seeded/spinach-cheese-omelet.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/images/dishes/seeded/greek-yogurt-with-nuts.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/images/dishes/seeded/rice-flour-syrniki.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/images/dishes/seeded/avocado-with-egg-and-tomatoes.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/images/dishes/seeded/rice-porridge-with-pumpkin.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/images/dishes/seeded/bulgur-with-chicken-and-vegetables.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/images/dishes/seeded/lentil-tomato-soup.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/images/dishes/seeded/tuna-tomato-pasta.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/images/dishes/seeded/quinoa-chickpea-bowl.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/images/dishes/seeded/turkey-meatballs-with-rice.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "/images/dishes/seeded/beef-borscht.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/images/dishes/seeded/shrimp-vegetable-rice.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/images/dishes/seeded/chicken-breast-with-broccoli.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "/images/dishes/seeded/beef-with-cauliflower.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "/images/dishes/seeded/vegetable-frittata.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "/images/dishes/seeded/tofu-vegetable-stir-fry.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "/images/dishes/seeded/salmon-patties-with-salad.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "/images/dishes/seeded/stuffed-pepper-with-rice.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "/images/dishes/seeded/warm-liver-apple-salad.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "/images/dishes/seeded/vegetable-sticks-with-hummus.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "/images/dishes/seeded/apple-with-peanut-butter.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "/images/dishes/seeded/protein-cottage-cheese-cocoa.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "/images/dishes/seeded/rice-cakes-with-avocado.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "/images/dishes/seeded/kefir-banana-smoothie.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "/images/dishes/breakfast.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/images/dishes/lunch.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "/images/dishes/dinner.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "/images/dishes/snack.svg");
        }
    }
}
