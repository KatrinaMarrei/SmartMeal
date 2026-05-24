namespace SmartMeal.Models.ViewModels
{
    public class MealPlanWeekViewModel
    {
        public int WeekNumber { get; set; }

        public string UserFullName { get; set; } = string.Empty;

        public decimal DailyCaloriesTarget { get; set; }

        public List<MealPlanDayViewModel> Days { get; set; } = new();
    }

    public class MealPlanDayViewModel
    {
        public int DayOfWeek { get; set; }

        public string DayName { get; set; } = string.Empty;

        public decimal TotalCalories { get; set; }

        public string Status { get; set; } = string.Empty;

        public List<MealPlanCellViewModel> Cells { get; set; } = new();
    }

    public class MealPlanCellViewModel
    {
        public int DayOfWeek { get; set; }

        public string MealType { get; set; } = string.Empty;

        public int? SelectedDishId { get; set; }

        public decimal SelectedCalories { get; set; }

        public List<string> SelectedDishMatchingUserAllergenNames { get; set; } = new();

        public bool HasAllergyWarning => SelectedDishMatchingUserAllergenNames.Any();

        public List<MealPlanDishOptionViewModel> DishOptions { get; set; } = new();
    }

    public class MealPlanDishOptionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Calories { get; set; }
    }
}
