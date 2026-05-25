namespace SmartMeal.Models.ViewModels
{
    public class HomeDashboardViewModel
    {
        public string DemoUserDisplayName { get; set; } = string.Empty;

        public decimal DailyCalorieTarget { get; set; }

        public decimal TodayActualCalories { get; set; }

        public string CalorieStatusText { get; set; } = string.Empty;

        public string CurrentDayName { get; set; } = string.Empty;

        public int CurrentWeekNumber { get; set; }

        public List<HomeDashboardMealViewModel> PlannedMeals { get; set; } = new();

        public List<HomeDashboardAllergyWarningViewModel> AllergyWarnings { get; set; } = new();

        public int PlannedMealsCount => PlannedMeals.Count(meal => meal.IsSelected);

        public int EmptyMealsCount => PlannedMeals.Count(meal => !meal.IsSelected);

        public bool HasAllergyWarnings => AllergyWarnings.Any();
    }

    public class HomeDashboardMealViewModel
    {
        public string MealType { get; set; } = string.Empty;

        public string DishName { get; set; } = "Не выбрано";

        public decimal Calories { get; set; }

        public List<string> MatchingAllergenNames { get; set; } = new();

        public bool IsSelected { get; set; }

        public bool HasAllergyWarning => MatchingAllergenNames.Any();
    }

    public class HomeDashboardAllergyWarningViewModel
    {
        public string MealType { get; set; } = string.Empty;

        public string DishName { get; set; } = string.Empty;

        public List<string> AllergenNames { get; set; } = new();
    }
}
