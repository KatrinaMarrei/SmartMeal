using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Gender { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Range(1, 300)]
        public decimal Weight { get; set; }

        [Range(1, 250)]
        public decimal Height { get; set; }

        [StringLength(100)]
        public string? Goal { get; set; }

        [Range(1, 5)]
        public int ActivityLevel { get; set; }

        [Range(0, 10000)]
        public decimal DailyCalories { get; set; }

        public ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();

        public ICollection<UserAllergen> UserAllergens { get; set; } = new List<UserAllergen>();

        public ICollection<Dish> CustomDishes { get; set; } = new List<Dish>();

        public ICollection<FavoriteDish> FavoriteDishes { get; set; } = new List<FavoriteDish>();
    }
}
