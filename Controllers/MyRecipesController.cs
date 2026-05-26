using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class MyRecipesController : Controller
    {
        private const int DemoUserProfileId = 1;

        private readonly ApplicationDbContext _context;

        public MyRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dishEntities = await _context.Dishes
                .AsNoTracking()
                .Include(d => d.Category)
                .Include(d => d.DishDietTypes)
                    .ThenInclude(dd => dd.DietType)
                .Include(d => d.DishAllergens)
                    .ThenInclude(da => da.Allergen)
                .Where(d => d.IsCustom && d.CreatedByUserProfileId == DemoUserProfileId)
                .OrderBy(d => d.Name)
                .ToListAsync();

            var userAllergenIds = await LoadDemoUserAllergenIdsAsync();

            var model = dishEntities
                .Select(d => new DishCatalogItemViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    CategoryName = d.Category != null ? d.Category.Name : "Без категории",
                    ImageUrl = DishImagePaths.WithFallback(d.ImageUrl),
                    Calories = d.Calories,
                    Proteins = d.Proteins,
                    Fats = d.Fats,
                    Carbs = d.Carbs,
                    CookingTime = d.CookingTime,
                    MainIngredient = d.MainIngredient,
                    IsForChildren = d.IsForChildren,
                    DietTypeNames = d.DishDietTypes
                        .Where(dd => dd.DietType != null)
                        .Select(dd => dd.DietType!.Name)
                        .OrderBy(name => name)
                        .ToList(),
                    AllergenNames = d.DishAllergens
                        .Where(da => da.Allergen != null)
                        .Select(da => da.Allergen!.Name)
                        .OrderBy(name => name)
                        .ToList(),
                    MatchingUserAllergenNames = GetMatchingUserAllergenNames(d, userAllergenIds)
                        .ToList()
                })
                .ToList();

            return View(model);
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
    }
}
