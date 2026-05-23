using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class SeedDishRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DishAllergens",
                columns: new[] { "AllergenId", "DishId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 3, 5 },
                    { 6, 5 },
                    { 1, 7 },
                    { 1, 8 },
                    { 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "DishDietTypes",
                columns: new[] { "DietTypeId", "DishId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 5, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 7, 4 },
                    { 1, 5 },
                    { 6, 5 },
                    { 7, 5 },
                    { 3, 6 },
                    { 5, 6 },
                    { 7, 6 },
                    { 5, 7 },
                    { 7, 7 },
                    { 1, 8 },
                    { 7, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 8 });
        }
    }
}
