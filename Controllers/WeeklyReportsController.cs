using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class WeeklyReportsController : Controller
    {
        private const int DemoUserProfileId = 1;

        private static readonly string[] DayNames =
        {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"
        };

        private readonly ApplicationDbContext _context;

        public WeeklyReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userProfile = await _context.UserProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == DemoUserProfileId);

            if (userProfile == null)
            {
                return NotFound("Демо-профиль не найден.");
            }

            var weekNumber = ISOWeek.GetWeekOfYear(DateTime.Today);
            var mealPlans = await _context.MealPlans
                .AsNoTracking()
                .Include(mp => mp.Dish)
                    .ThenInclude(d => d!.DishAllergens)
                        .ThenInclude(da => da.Allergen)
                .Where(mp => mp.UserProfileId == DemoUserProfileId && mp.WeekNumber == weekNumber)
                .ToListAsync();

            var userAllergenIds = await _context.UserAllergens
                .AsNoTracking()
                .Where(ua => ua.UserProfileId == DemoUserProfileId)
                .Select(ua => ua.AllergenId)
                .Distinct()
                .ToListAsync();

            var model = BuildReportViewModel(
                userProfile,
                weekNumber,
                mealPlans,
                userAllergenIds.ToHashSet());

            return View(model);
        }

        private static WeeklyReportViewModel BuildReportViewModel(
            UserProfile userProfile,
            int weekNumber,
            List<MealPlan> mealPlans,
            HashSet<int> userAllergenIds)
        {
            var mealPlansByDay = mealPlans
                .Where(mp => mp.DayOfWeek >= 1 && mp.DayOfWeek <= 7)
                .GroupBy(mp => mp.DayOfWeek)
                .ToDictionary(group => group.Key, group => group.ToList());

            var model = new WeeklyReportViewModel
            {
                WeekNumber = weekNumber,
                DemoUserDisplayName = userProfile.FullName,
                DailyCalorieTarget = userProfile.DailyCalories
            };

            for (var dayNumber = 1; dayNumber <= DayNames.Length; dayNumber++)
            {
                mealPlansByDay.TryGetValue(dayNumber, out var dayMealPlans);
                dayMealPlans ??= new List<MealPlan>();

                var dayCalories = dayMealPlans.Sum(mp => mp.Dish?.Calories ?? 0m);
                var dayProteins = dayMealPlans.Sum(mp => mp.Dish?.Proteins ?? 0m);
                var dayFats = dayMealPlans.Sum(mp => mp.Dish?.Fats ?? 0m);
                var dayCarbs = dayMealPlans.Sum(mp => mp.Dish?.Carbs ?? 0m);

                model.Days.Add(new WeeklyReportDayViewModel
                {
                    DayOfWeek = dayNumber,
                    DayName = DayNames[dayNumber - 1],
                    Calories = dayCalories,
                    Proteins = dayProteins,
                    Fats = dayFats,
                    Carbs = dayCarbs,
                    Status = GetDailyStatus(dayCalories, userProfile.DailyCalories),
                    CalorieProgressPercent = GetCalorieProgressPercent(dayCalories, userProfile.DailyCalories)
                });

                AddAllergyWarnings(model, dayMealPlans, DayNames[dayNumber - 1], userAllergenIds);
            }

            model.WeeklyTotalCalories = model.Days.Sum(day => day.Calories);
            model.WeeklyTotalProteins = model.Days.Sum(day => day.Proteins);
            model.WeeklyTotalFats = model.Days.Sum(day => day.Fats);
            model.WeeklyTotalCarbs = model.Days.Sum(day => day.Carbs);

            return model;
        }

        private static void AddAllergyWarnings(
            WeeklyReportViewModel model,
            List<MealPlan> mealPlans,
            string dayName,
            HashSet<int> userAllergenIds)
        {
            if (userAllergenIds.Count == 0)
            {
                return;
            }

            foreach (var mealPlan in mealPlans)
            {
                var matchingAllergens = GetMatchingUserAllergenNames(mealPlan.Dish, userAllergenIds);

                if (matchingAllergens.Count == 0 || mealPlan.Dish == null)
                {
                    continue;
                }

                model.AllergyWarnings.Add(new WeeklyReportAllergyWarningViewModel
                {
                    DayName = dayName,
                    MealType = mealPlan.MealType,
                    DishName = mealPlan.Dish.Name,
                    AllergenNames = matchingAllergens
                });
            }
        }

        private static List<string> GetMatchingUserAllergenNames(Dish? dish, HashSet<int> userAllergenIds)
        {
            if (dish == null || userAllergenIds.Count == 0)
            {
                return new List<string>();
            }

            return dish.DishAllergens
                .Where(da => userAllergenIds.Contains(da.AllergenId) && da.Allergen != null)
                .Select(da => da.Allergen!.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();
        }

        private static string GetDailyStatus(decimal totalCalories, decimal targetCalories)
        {
            if (totalCalories == 0m)
            {
                return "Недобор";
            }

            if (totalCalories < targetCalories * 0.9m)
            {
                return "Недобор";
            }

            if (totalCalories > targetCalories * 1.1m)
            {
                return "Превышение";
            }

            return "В норме";
        }

        private static int GetCalorieProgressPercent(decimal totalCalories, decimal targetCalories)
        {
            if (targetCalories <= 0)
            {
                return 0;
            }

            var percent = totalCalories / targetCalories * 100m;

            return (int)Math.Min(Math.Round(percent), 100m);
        }
    }
}
