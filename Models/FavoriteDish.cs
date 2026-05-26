namespace SmartMeal.Models
{
    public class FavoriteDish
    {
        public int UserProfileId { get; set; }

        public UserProfile? UserProfile { get; set; }

        public int DishId { get; set; }

        public Dish? Dish { get; set; }
    }
}
