namespace SmartMeal.Models.ViewModels
{
    public class WeeklyReportViewModel
    {
        public int WeekNumber { get; set; }

        public string DemoUserDisplayName { get; set; } = string.Empty;

        public decimal DailyCalorieTarget { get; set; }

        public List<WeeklyReportDayViewModel> Days { get; set; } = new();

        public decimal WeeklyTotalCalories { get; set; }

        public decimal AverageCaloriesPerDay => WeeklyTotalCalories / 7m;

        public decimal WeeklyTotalProteins { get; set; }

        public decimal WeeklyTotalFats { get; set; }

        public decimal WeeklyTotalCarbs { get; set; }

        public int DaysBelowTargetCount => Days.Count(day => day.Status == "Недобор");

        public int DaysInTargetRangeCount => Days.Count(day => day.Status == "В норме");

        public int DaysAboveTargetCount => Days.Count(day => day.Status == "Превышение");

        public List<WeeklyReportAllergyWarningViewModel> AllergyWarnings { get; set; } = new();

        public bool HasAllergyWarnings => AllergyWarnings.Any();
    }

    public class WeeklyReportDayViewModel
    {
        public int DayOfWeek { get; set; }

        public string DayName { get; set; } = string.Empty;

        public decimal Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbs { get; set; }

        public string Status { get; set; } = string.Empty;

        public int CalorieProgressPercent { get; set; }
    }

    public class WeeklyReportAllergyWarningViewModel
    {
        public string DayName { get; set; } = string.Empty;

        public string MealType { get; set; } = string.Empty;

        public string DishName { get; set; } = string.Empty;

        public List<string> AllergenNames { get; set; } = new();
    }
}
