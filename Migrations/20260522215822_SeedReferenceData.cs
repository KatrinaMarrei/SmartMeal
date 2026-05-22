using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class SeedReferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Молочные продукты и лактоза.", "Молоко" },
                    { 2, "Орехи и продукты, которые могут содержать следы орехов.", "Орехи" },
                    { 3, "Апельсины, лимоны, мандарины и другие цитрусовые.", "Цитрусовые" },
                    { 4, "Пшеница, рожь, ячмень и продукты с глютеном.", "Глютен" },
                    { 5, "Куриные яйца и продукты с их содержанием.", "Яйца" },
                    { 6, "Рыба и рыбные продукты.", "Рыба" },
                    { 7, "Креветки, мидии, кальмары и другие морепродукты.", "Морепродукты" },
                    { 8, "Соя и соевые продукты.", "Соя" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "Завтрак", 1 },
                    { 2, "Обед", 2 },
                    { 3, "Ужин", 3 },
                    { 4, "Перекус", 4 }
                });

            migrationBuilder.InsertData(
                table: "DietTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Рацион с повышенным содержанием белка.", "Высокобелковая" },
                    { 2, "Рацион без продуктов, содержащих глютен.", "Без глютена" },
                    { 3, "Рацион без мясных продуктов.", "Вегетарианская" },
                    { 4, "Рацион с низким содержанием углеводов и высоким содержанием жиров.", "Кето" },
                    { 5, "Рацион с пониженной калорийностью.", "Низкокалорийная" },
                    { 6, "Рацион с ограничением углеводов.", "Низкоуглеводная" },
                    { 7, "Сбалансированный рацион для здорового питания.", "Правильное питание" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DietTypes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
