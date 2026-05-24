using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "ActivityLevel", "Age", "DailyCalories", "Email", "FullName", "Gender", "Goal", "Height", "Weight" },
                values: new object[] { 1, 3, 22, 2000m, "demo@smartmeal.local", "Демо-пользователь", "Женский", "Поддержание веса", 170m, 65m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
