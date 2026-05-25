namespace SmartMeal.Models.ViewModels
{
    public class DishCatalogViewModel
    {
        public int? CategoryId { get; set; }

        public string? SearchQuery { get; set; }

        public string? MainIngredient { get; set; }

        public int? MaxCookingTime { get; set; }

        public bool? IsForChildren { get; set; }

        public int? DietTypeId { get; set; }

        public int? AllergenId { get; set; }

        public List<DishCatalogItemViewModel> Dishes { get; set; } = new();

        public List<FilterOptionViewModel> Categories { get; set; } = new();

        public List<FilterOptionViewModel> DietTypes { get; set; } = new();

        public List<FilterOptionViewModel> Allergens { get; set; } = new();

        public List<string> MainIngredients { get; set; } = new();
    }

    public class FilterOptionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
