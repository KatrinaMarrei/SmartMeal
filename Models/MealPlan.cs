using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models
{
    public class MealPlan
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public UserProfile? UserProfile { get; set; }

        public int DishId { get; set; }

        public Dish? Dish { get; set; }

        [Range(1, 7)]
        public int DayOfWeek { get; set; }

        [Required]
        [StringLength(50)]
        public string MealType { get; set; } = string.Empty;

        [Range(1, 53)]
        public int WeekNumber { get; set; }

        public bool IsApproved { get; set; }
    }
}