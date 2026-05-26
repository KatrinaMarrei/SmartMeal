namespace SmartMeal.Models
{
    public static class DishImagePaths
    {
        public const string Breakfast = "/images/dishes/breakfast.svg";
        public const string Lunch = "/images/dishes/lunch.svg";
        public const string Dinner = "/images/dishes/dinner.svg";
        public const string Snack = "/images/dishes/snack.svg";
        public const string Default = "/images/dishes/default.svg";

        public static string ForCategory(int categoryId)
        {
            return categoryId switch
            {
                1 => Breakfast,
                2 => Lunch,
                3 => Dinner,
                4 => Snack,
                _ => Default
            };
        }

        public static string WithFallback(string? imageUrl)
        {
            return string.IsNullOrWhiteSpace(imageUrl) ? Default : imageUrl;
        }
    }
}
