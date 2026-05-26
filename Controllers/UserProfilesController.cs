using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;
using SmartMeal.Services;

namespace SmartMeal.Controllers
{
    public class UserProfilesController : Controller
    {
        private const int DemoUserProfileId = 1;

        private readonly ApplicationDbContext _context;

        public UserProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userProfile = await _context.UserProfiles
                .AsNoTracking()
                .Include(u => u.UserAllergens)
                    .ThenInclude(ua => ua.Allergen)
                .FirstOrDefaultAsync(u => u.Id == DemoUserProfileId);

            if (userProfile == null)
            {
                return NotFound("Демо-профиль не найден.");
            }

            var model = MapToViewModel(userProfile);

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var userProfile = await _context.UserProfiles
                .AsNoTracking()
                .Include(u => u.UserAllergens)
                .FirstOrDefaultAsync(u => u.Id == DemoUserProfileId);

            if (userProfile == null)
            {
                return NotFound("Демо-профиль не найден.");
            }

            var model = MapToViewModel(userProfile);
            await LoadAllergenOptionsAsync(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserProfileViewModel model)
        {
            var selectedAllergenIds = model.SelectedAllergenIds
                .Distinct()
                .ToList();

            var validAllergenIds = await _context.Allergens
                .AsNoTracking()
                .Where(a => selectedAllergenIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            if (validAllergenIds.Count != selectedAllergenIds.Count)
            {
                ModelState.AddModelError(nameof(model.SelectedAllergenIds), "Выберите существующие аллергены.");
            }

            if (CalorieCalculator.TryCalculate(
                model.Gender,
                model.Age,
                model.Weight,
                model.Height,
                model.ActivityLevel,
                model.Goal,
                out var calculatedDailyCalories))
            {
                model.DailyCalories = calculatedDailyCalories;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Не удалось рассчитать норму калорий. Проверьте пол, возраст, вес, рост, уровень активности и цель.");
            }

            if (!ModelState.IsValid)
            {
                model.SelectedAllergenIds = selectedAllergenIds;
                await LoadAllergenOptionsAsync(model);

                return View(model);
            }

            var userProfile = await _context.UserProfiles
                .Include(u => u.UserAllergens)
                .FirstOrDefaultAsync(u => u.Id == DemoUserProfileId);

            if (userProfile == null)
            {
                return NotFound("Демо-профиль не найден.");
            }

            userProfile.FullName = model.FullName;
            userProfile.Email = model.Email;
            userProfile.Gender = model.Gender;
            userProfile.Age = model.Age;
            userProfile.Weight = model.Weight;
            userProfile.Height = model.Height;
            userProfile.Goal = model.Goal;
            userProfile.ActivityLevel = model.ActivityLevel;
            userProfile.DailyCalories = calculatedDailyCalories;

            _context.UserAllergens.RemoveRange(userProfile.UserAllergens);

            userProfile.UserAllergens = selectedAllergenIds
                .Select(allergenId => new UserAllergen
                {
                    UserProfileId = DemoUserProfileId,
                    AllergenId = allergenId
                })
                .ToList();

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private static UserProfileViewModel MapToViewModel(UserProfile userProfile)
        {
            return new UserProfileViewModel
            {
                Id = userProfile.Id,
                FullName = userProfile.FullName,
                Email = userProfile.Email,
                Gender = userProfile.Gender,
                Age = userProfile.Age,
                Weight = userProfile.Weight,
                Height = userProfile.Height,
                Goal = userProfile.Goal,
                ActivityLevel = userProfile.ActivityLevel,
                DailyCalories = userProfile.DailyCalories,
                SelectedAllergenIds = userProfile.UserAllergens
                    .Select(ua => ua.AllergenId)
                    .Distinct()
                    .ToList(),
                Allergens = userProfile.UserAllergens
                    .Where(ua => ua.Allergen != null)
                    .Select(ua => new FilterOptionViewModel
                    {
                        Id = ua.AllergenId,
                        Name = ua.Allergen!.Name
                    })
                    .OrderBy(a => a.Name)
                    .ToList()
            };
        }

        private async Task LoadAllergenOptionsAsync(UserProfileViewModel model)
        {
            model.Allergens = await _context.Allergens
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .Select(a => new FilterOptionViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }
    }
}
