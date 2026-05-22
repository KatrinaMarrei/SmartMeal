using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models
{
    public class DietType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<DishDietType> DishDietTypes { get; set; } = new List<DishDietType>();
    }
}