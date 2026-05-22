using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}