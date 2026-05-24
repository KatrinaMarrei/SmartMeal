using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class MealPlansController : Controller
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

        public MealPlansController(ApplicationDbContext context)
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
                return NotFound("Демо-пользователь не найден.");
            }

            var weekNumber = GetCurrentWeekNumber();
            var mealPlans = await _context.MealPlans
                .AsNoTracking()
                .Include(mp => mp.Dish)
                    .ThenInclude(d => d!.DishAllergens)
                        .ThenInclude(da => da.Allergen)
                .Where(mp => mp.UserProfileId == DemoUserProfileId && mp.WeekNumber == weekNumber)
                .ToListAsync();

            var userAllergenIds = await LoadDemoUserAllergenIdsAsync();
            var dishesByMealType = await LoadDishOptionsByMealTypeAsync();
            var model = BuildWeekViewModel(userProfile, weekNumber, mealPlans, dishesByMealType, userAllergenIds);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(MealPlanWeekViewModel model)
        {
            var weekNumber = GetCurrentWeekNumber();
            var validMealTypes = MealTypes.ToHashSet();
            var validDishIds = await _context.Dishes
                .AsNoTracking()
                .Select(d => d.Id)
                .ToListAsync();
            var validDishIdSet = validDishIds.ToHashSet();

            var existingPlans = await _context.MealPlans
                .Where(mp => mp.UserProfileId == DemoUserProfileId && mp.WeekNumber == weekNumber)
                .ToListAsync();

            var existingBySlot = existingPlans
                .GroupBy(mp => new { mp.DayOfWeek, mp.MealType })
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var day in model.Days)
            {
                if (day.DayOfWeek < 1 || day.DayOfWeek > 7)
                {
                    continue;
                }

                foreach (var cell in day.Cells)
                {
                    if (!validMealTypes.Contains(cell.MealType))
                    {
                        continue;
                    }

                    var key = new { day.DayOfWeek, cell.MealType };
                    existingBySlot.TryGetValue(key, out var plansForSlot);
                    var currentPlan = plansForSlot?.FirstOrDefault();

                    if (cell.SelectedDishId.HasValue && validDishIdSet.Contains(cell.SelectedDishId.Value))
                    {
                        if (currentPlan == null)
                        {
                            _context.MealPlans.Add(new MealPlan
                            {
                                UserProfileId = DemoUserProfileId,
                                DishId = cell.SelectedDishId.Value,
                                DayOfWeek = day.DayOfWeek,
                                MealType = cell.MealType,
                                WeekNumber = weekNumber,
                                IsApproved = false
                            });
                        }
                        else
                        {
                            currentPlan.DishId = cell.SelectedDishId.Value;
                        }

                        if (plansForSlot != null && plansForSlot.Count > 1)
                        {
                            _context.MealPlans.RemoveRange(plansForSlot.Skip(1));
                        }
                    }
                    else if (plansForSlot != null)
                    {
                        _context.MealPlans.RemoveRange(plansForSlot);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private static int GetCurrentWeekNumber()
        {
            return ISOWeek.GetWeekOfYear(DateTime.Today);
        }

        private static MealPlanWeekViewModel BuildWeekViewModel(
            UserProfile userProfile,
            int weekNumber,
            List<MealPlan> mealPlans,
            Dictionary<string, List<MealPlanDishOptionViewModel>> dishesByMealType,
            HashSet<int> userAllergenIds)
        {
            var plansBySlot = mealPlans
                .GroupBy(mp => new { mp.DayOfWeek, mp.MealType })
                .ToDictionary(group => group.Key, group => group.First());

            var model = new MealPlanWeekViewModel
            {
                WeekNumber = weekNumber,
                UserFullName = userProfile.FullName,
                DailyCaloriesTarget = userProfile.DailyCalories
            };

            for (var dayNumber = 1; dayNumber <= DayNames.Length; dayNumber++)
            {
                var day = new MealPlanDayViewModel
                {
                    DayOfWeek = dayNumber,
                    DayName = DayNames[dayNumber - 1]
                };

                foreach (var mealType in MealTypes)
                {
                    var key = new { DayOfWeek = dayNumber, MealType = mealType };
                    plansBySlot.TryGetValue(key, out var mealPlan);
                    dishesByMealType.TryGetValue(mealType, out var options);

                    var selectedCalories = mealPlan?.Dish?.Calories ?? 0m;
                    day.Cells.Add(new MealPlanCellViewModel
                    {
                        DayOfWeek = dayNumber,
                        MealType = mealType,
                        SelectedDishId = mealPlan?.DishId,
                        SelectedCalories = selectedCalories,
                        SelectedDishMatchingUserAllergenNames = GetMatchingUserAllergenNames(mealPlan?.Dish, userAllergenIds),
                        DishOptions = options ?? new List<MealPlanDishOptionViewModel>()
                    });
                    day.TotalCalories += selectedCalories;
                }

                day.Status = GetDailyStatus(day.TotalCalories, userProfile.DailyCalories);
                model.Days.Add(day);
            }

            return model;
        }

        private async Task<HashSet<int>> LoadDemoUserAllergenIdsAsync()
        {
            var allergenIds = await _context.UserAllergens
                .AsNoTracking()
                .Where(ua => ua.UserProfileId == DemoUserProfileId)
                .Select(ua => ua.AllergenId)
                .Distinct()
                .ToListAsync();

            return allergenIds.ToHashSet();
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

        private async Task<Dictionary<string, List<MealPlanDishOptionViewModel>>> LoadDishOptionsByMealTypeAsync()
        {
            var dishes = await _context.Dishes
                .AsNoTracking()
                .Include(d => d.Category)
                .OrderBy(d => d.Category!.SortOrder)
                .ThenBy(d => d.Name)
                .ToListAsync();

            return MealTypes.ToDictionary(
                mealType => mealType,
                mealType => dishes
                    .Where(d => d.Category != null && d.Category.Name == mealType)
                    .Select(d => new MealPlanDishOptionViewModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Calories = d.Calories
                    })
                    .ToList());
        }

        private static string GetDailyStatus(decimal totalCalories, decimal targetCalories)
        {
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
    }
}
