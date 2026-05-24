namespace SmartMeal.Models.ViewModels
{
    public class DishDetailsViewModel
    {
        public bool IsFound { get; set; }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public decimal Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbs { get; set; }

        public int CookingTime { get; set; }

        public string IngredientsList { get; set; } = string.Empty;

        public string? MainIngredient { get; set; }

        public bool IsForChildren { get; set; }

        public bool IsCustom { get; set; }

        public List<string> DietTypeNames { get; set; } = new();

        public List<string> AllergenNames { get; set; } = new();

        public List<string> MatchingUserAllergenNames { get; set; } = new();

        public bool HasAllergyWarning => MatchingUserAllergenNames.Any();
    }
}
