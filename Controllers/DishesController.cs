using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMeal.Data;
using SmartMeal.Models.ViewModels;

namespace SmartMeal.Controllers
{
    public class DishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            int? categoryId,
            string? mainIngredient,
            int? maxCookingTime,
            bool? isForChildren,
            int? dietTypeId,
            int? allergenId)
        {
            IQueryable<Models.Dish> query = _context.Dishes
                .AsNoTracking()
                .Include(d => d.Category)
                .Include(d => d.DishDietTypes)
                    .ThenInclude(dd => dd.DietType)
                .Include(d => d.DishAllergens)
                    .ThenInclude(da => da.Allergen);

            if (categoryId.HasValue)
            {
                query = query.Where(d => d.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(mainIngredient))
            {
                query = query.Where(d => d.MainIngredient == mainIngredient);
            }

            if (maxCookingTime.HasValue)
            {
                query = query.Where(d => d.CookingTime <= maxCookingTime.Value);
            }

            if (isForChildren.HasValue)
            {
                query = query.Where(d => d.IsForChildren == isForChildren.Value);
            }

            if (dietTypeId.HasValue)
            {
                query = query.Where(d => d.DishDietTypes.Any(dd => dd.DietTypeId == dietTypeId.Value));
            }

            if (allergenId.HasValue)
            {
                query = query.Where(d => d.DishAllergens.Any(da => da.AllergenId == allergenId.Value));
            }

            var dishEntities = await query
                .OrderBy(d => d.Category!.SortOrder)
                .ThenBy(d => d.Name)
                .ToListAsync();

            var dishes = dishEntities
                .Select(d => new DishCatalogItemViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    CategoryName = d.Category != null ? d.Category.Name : "Без категории",
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
                        .ToList()
                })
                .ToList();

            var model = new DishCatalogViewModel
            {
                CategoryId = categoryId,
                MainIngredient = mainIngredient,
                MaxCookingTime = maxCookingTime,
                IsForChildren = isForChildren,
                DietTypeId = dietTypeId,
                AllergenId = allergenId,
                Dishes = dishes,
                Categories = await _context.Categories
                    .AsNoTracking()
                    .OrderBy(c => c.SortOrder)
                    .Select(c => new FilterOptionViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToListAsync(),
                DietTypes = await _context.DietTypes
                    .AsNoTracking()
                    .OrderBy(dt => dt.Name)
                    .Select(dt => new FilterOptionViewModel
                    {
                        Id = dt.Id,
                        Name = dt.Name
                    })
                    .ToListAsync(),
                Allergens = await _context.Allergens
                    .AsNoTracking()
                    .OrderBy(a => a.Name)
                    .Select(a => new FilterOptionViewModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .ToListAsync(),
                MainIngredients = await _context.Dishes
                    .AsNoTracking()
                    .Where(d => d.MainIngredient != null && d.MainIngredient != "")
                    .Select(d => d.MainIngredient!)
                    .Distinct()
                    .OrderBy(ingredient => ingredient)
                    .ToListAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dish = await _context.Dishes
                .AsNoTracking()
                .Include(d => d.Category)
                .Include(d => d.DishDietTypes)
                    .ThenInclude(dd => dd.DietType)
                .Include(d => d.DishAllergens)
                    .ThenInclude(da => da.Allergen)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null)
            {
                return View(new DishDetailsViewModel { IsFound = false });
            }

            var model = new DishDetailsViewModel
            {
                IsFound = true,
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                CategoryName = dish.Category != null ? dish.Category.Name : "Без категории",
                Calories = dish.Calories,
                Proteins = dish.Proteins,
                Fats = dish.Fats,
                Carbs = dish.Carbs,
                CookingTime = dish.CookingTime,
                IngredientsList = dish.IngredientsList,
                MainIngredient = dish.MainIngredient,
                IsForChildren = dish.IsForChildren,
                IsCustom = dish.IsCustom,
                DietTypeNames = dish.DishDietTypes
                    .Where(dd => dd.DietType != null)
                    .Select(dd => dd.DietType!.Name)
                    .OrderBy(name => name)
                    .ToList(),
                AllergenNames = dish.DishAllergens
                    .Where(da => da.Allergen != null)
                    .Select(da => da.Allergen!.Name)
                    .OrderBy(name => name)
                    .ToList()
            };

            return View(model);
        }
    }
}
