namespace SmartMeal.Models
{
    public class UserAllergen
    {
        public int UserProfileId { get; set; }

        public UserProfile? UserProfile { get; set; }

        public int AllergenId { get; set; }

        public Allergen? Allergen { get; set; }
    }
}