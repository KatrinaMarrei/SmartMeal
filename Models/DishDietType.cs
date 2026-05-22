namespace SmartMeal.Models
{
    public class DishDietType
    {
        public int DishId { get; set; }

        public Dish? Dish { get; set; }

        public int DietTypeId { get; set; }

        public DietType? DietType { get; set; }
    }
}