using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class FavoritesController : Controller
    {
        private const int DemoUserProfileId = 1;

        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dishEntities = await _context.FavoriteDishes
                .AsNoTracking()
                .Where(fd => fd.UserProfileId == DemoUserProfileId)
                .Include(fd => fd.Dish!)
                    .ThenInclude(d => d.Category)
                .Include(fd => fd.Dish!)
                    .ThenInclude(d => d.DishDietTypes)
                        .ThenInclude(dd => dd.DietType)
                .Include(fd => fd.Dish!)
                    .ThenInclude(d => d.DishAllergens)
                        .ThenInclude(da => da.Allergen)
                .Select(fd => fd.Dish!)
                .OrderBy(d => d.Category!.SortOrder)
                .ThenBy(d => d.Name)
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
                    IsFavorite = true,
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
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int dishId, string? returnUrl)
        {
            var dishExists = await _context.Dishes
                .AsNoTracking()
                .AnyAsync(d => d.Id == dishId);

            if (dishExists)
            {
                var favoriteExists = await _context.FavoriteDishes
                    .AsNoTracking()
                    .AnyAsync(fd => fd.UserProfileId == DemoUserProfileId && fd.DishId == dishId);

                if (!favoriteExists)
                {
                    _context.FavoriteDishes.Add(new FavoriteDish
                    {
                        UserProfileId = DemoUserProfileId,
                        DishId = dishId
                    });

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToLocalOrFavorites(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int dishId, string? returnUrl)
        {
            var favorite = await _context.FavoriteDishes
                .FirstOrDefaultAsync(fd => fd.UserProfileId == DemoUserProfileId && fd.DishId == dishId);

            if (favorite != null)
            {
                _context.FavoriteDishes.Remove(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToLocalOrFavorites(returnUrl);
        }

        private IActionResult RedirectToLocalOrFavorites(string? returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction(nameof(Index));
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
