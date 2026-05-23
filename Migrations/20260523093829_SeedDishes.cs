using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class SeedDishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbs", "CategoryId", "CookingTime", "CreatedByUserProfileId", "Description", "Fats", "ImageUrl", "IngredientsList", "IsCustom", "IsForChildren", "MainIngredient", "Name", "Proteins" },
                values: new object[,]
                {
                    { 1, 310m, 54m, 1, 15, null, "Теплая овсяная каша на завтрак с кусочками яблока и корицей.", 7m, null, "Овсяные хлопья, молоко, яблоко, корица, мед", false, true, "Овсяные хлопья", "Овсяная каша с яблоком", 9m },
                    { 2, 360m, 34m, 1, 45, null, "Нежная запеканка из творога с легкой сладостью и мягкой текстурой.", 14m, null, "Творог, яйцо, манная крупа, сметана, сахар", false, true, "Творог", "Творожная запеканка", 24m },
                    { 3, 280m, 30m, 2, 50, null, "Легкий обеденный суп с курицей, картофелем, морковью и зеленью.", 8m, null, "Куриное филе, картофель, морковь, лук, зелень", false, true, "Курица", "Куриный суп с овощами", 22m },
                    { 4, 470m, 55m, 2, 40, null, "Сытное блюдо для обеда из рассыпчатой гречки и тушеной индейки.", 12m, null, "Гречневая крупа, филе индейки, морковь, лук, растительное масло", false, true, "Индейка", "Гречка с индейкой", 35m },
                    { 5, 390m, 25m, 3, 35, null, "Ужин из белой рыбы, запеченной с кабачком, перцем и томатами.", 16m, null, "Белая рыба, кабачок, болгарский перец, томаты, лимонный сок", false, false, "Рыба", "Запеченная рыба с овощами", 32m },
                    { 6, 340m, 48m, 3, 45, null, "Питательное овощное рагу с фасолью, томатами и ароматными специями.", 9m, null, "Фасоль, картофель, морковь, томаты, лук, специи", false, false, "Фасоль", "Овощное рагу с фасолью", 15m },
                    { 7, 190m, 26m, 4, 5, null, "Быстрый перекус из натурального йогурта со свежими ягодами.", 5m, null, "Натуральный йогурт, ягоды, овсяные хлопья", false, true, "Йогурт", "Йогурт с ягодами", 10m },
                    { 8, 330m, 35m, 4, 10, null, "Простой перекус с куриным филе, овощами и цельнозерновым хлебом.", 10m, null, "Цельнозерновой хлеб, куриное филе, огурец, лист салата, йогуртовый соус", false, true, "Курица", "Сэндвич с курицей", 24m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
