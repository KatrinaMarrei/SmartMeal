using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class HomeController : Controller
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

        private static readonly string[] MealTypes =
        {
            "Завтрак",
            "Обед",
            "Ужин",
            "Перекус"
        };

        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
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

            var currentDayOfWeek = GetCurrentAppDayOfWeek();
            var currentWeekNumber = ISOWeek.GetWeekOfYear(DateTime.Today);

            var mealPlans = await _context.MealPlans
                .AsNoTracking()
                .Include(mp => mp.Dish)
                    .ThenInclude(d => d!.DishAllergens)
                        .ThenInclude(da => da.Allergen)
                .Where(mp =>
                    mp.UserProfileId == DemoUserProfileId &&
                    mp.WeekNumber == currentWeekNumber &&
                    mp.DayOfWeek == currentDayOfWeek)
                .ToListAsync();

            var userAllergenIds = await _context.UserAllergens
                .AsNoTracking()
                .Where(ua => ua.UserProfileId == DemoUserProfileId)
                .Select(ua => ua.AllergenId)
                .Distinct()
                .ToListAsync();

            var userAllergenIdSet = userAllergenIds.ToHashSet();
            var mealPlansByType = mealPlans
                .GroupBy(mp => mp.MealType)
                .ToDictionary(group => group.Key, group => group.First());

            var plannedMeals = MealTypes
                .Select(mealType => BuildMealViewModel(mealType, mealPlansByType, userAllergenIdSet))
                .ToList();

            var todayActualCalories = plannedMeals.Sum(meal => meal.Calories);

            var model = new HomeDashboardViewModel
            {
                DemoUserDisplayName = userProfile.FullName,
                DailyCalorieTarget = userProfile.DailyCalories,
                TodayActualCalories = todayActualCalories,
                CalorieStatusText = GetCalorieStatus(todayActualCalories, userProfile.DailyCalories),
                CurrentDayName = DayNames[currentDayOfWeek - 1],
                CurrentWeekNumber = currentWeekNumber,
                PlannedMeals = plannedMeals,
                AllergyWarnings = plannedMeals
                    .Where(meal => meal.HasAllergyWarning)
                    .Select(meal => new HomeDashboardAllergyWarningViewModel
                    {
                        MealType = meal.MealType,
                        DishName = meal.DishName,
                        AllergenNames = meal.MatchingAllergenNames
                    })
                    .ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static int GetCurrentAppDayOfWeek()
        {
            return DateTime.Today.DayOfWeek == DayOfWeek.Sunday
                ? 7
                : (int)DateTime.Today.DayOfWeek;
        }

        private static HomeDashboardMealViewModel BuildMealViewModel(
            string mealType,
            Dictionary<string, MealPlan> mealPlansByType,
            HashSet<int> userAllergenIds)
        {
            if (!mealPlansByType.TryGetValue(mealType, out var mealPlan) || mealPlan.Dish == null)
            {
                return new HomeDashboardMealViewModel
                {
                    MealType = mealType
                };
            }

            return new HomeDashboardMealViewModel
            {
                MealType = mealType,
                DishName = mealPlan.Dish.Name,
                Calories = mealPlan.Dish.Calories,
                MatchingAllergenNames = GetMatchingUserAllergenNames(mealPlan.Dish, userAllergenIds),
                IsSelected = true
            };
        }

        private static List<string> GetMatchingUserAllergenNames(Dish dish, HashSet<int> userAllergenIds)
        {
            if (userAllergenIds.Count == 0)
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

        private static string GetCalorieStatus(decimal actualCalories, decimal targetCalories)
        {
            if (actualCalories < targetCalories * 0.9m)
            {
                return "Недобор";
            }

            if (actualCalories > targetCalories * 1.1m)
            {
                return "Превышение";
            }

            return "В норме";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
