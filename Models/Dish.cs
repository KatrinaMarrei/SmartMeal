using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(0, 10000)]
        public decimal Calories { get; set; }

        [Range(0, 1000)]
        public decimal Proteins { get; set; }

        [Range(0, 1000)]
        public decimal Fats { get; set; }

        [Range(0, 1000)]
        public decimal Carbs { get; set; }

        [Range(0, 1000)]
        public int CookingTime { get; set; }

        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public string IngredientsList { get; set; } = string.Empty;

        [StringLength(100)]
        public string? MainIngredient { get; set; }

        public bool IsForChildren { get; set; }

        public bool IsCustom { get; set; }

        public int? CreatedByUserProfileId { get; set; }

        public UserProfile? CreatedByUserProfile { get; set; }

        public ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();

        public ICollection<DishAllergen> DishAllergens { get; set; } = new List<DishAllergen>();

        public ICollection<DishDietType> DishDietTypes { get; set; } = new List<DishDietType>();
    }
}