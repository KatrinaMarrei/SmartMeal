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
            bool? isForChildren)
        {
            IQueryable<Models.Dish> query = _context.Dishes
                .AsNoTracking()
                .Include(d => d.Category);

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

            var dishes = await query
                .OrderBy(d => d.Category!.SortOrder)
                .ThenBy(d => d.Name)
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
                    IsForChildren = d.IsForChildren
                })
                .ToListAsync();

            var model = new DishCatalogViewModel
            {
                CategoryId = categoryId,
                MainIngredient = mainIngredient,
                MaxCookingTime = maxCookingTime,
                IsForChildren = isForChildren,
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
                .Where(d => d.Id == id)
                .Select(d => new DishDetailsViewModel
                {
                    IsFound = true,
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    CategoryName = d.Category != null ? d.Category.Name : "Без категории",
                    Calories = d.Calories,
                    Proteins = d.Proteins,
                    Fats = d.Fats,
                    Carbs = d.Carbs,
                    CookingTime = d.CookingTime,
                    IngredientsList = d.IngredientsList,
                    MainIngredient = d.MainIngredient,
                    IsForChildren = d.IsForChildren,
                    IsCustom = d.IsCustom
                })
                .FirstOrDefaultAsync();

            if (dish == null)
            {
                return View(new DishDetailsViewModel { IsFound = false });
            }

            return View(dish);
        }
    }
}
