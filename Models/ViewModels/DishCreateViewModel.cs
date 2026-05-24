using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models.ViewModels
{
    public class DishCreateViewModel
    {
        [Required(ErrorMessage = "Введите название рецепта.")]
        [StringLength(150, ErrorMessage = "Название не должно быть длиннее 150 символов.")]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите описание рецепта.")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Выберите категорию.")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Range(0, 10000, ErrorMessage = "Калории должны быть от 0 до 10000.")]
        [Display(Name = "Калории")]
        public decimal Calories { get; set; }

        [Range(0, 1000, ErrorMessage = "Белки должны быть от 0 до 1000.")]
        [Display(Name = "Белки")]
        public decimal Proteins { get; set; }

        [Range(0, 1000, ErrorMessage = "Жиры должны быть от 0 до 1000.")]
        [Display(Name = "Жиры")]
        public decimal Fats { get; set; }

        [Range(0, 1000, ErrorMessage = "Углеводы должны быть от 0 до 1000.")]
        [Display(Name = "Углеводы")]
        public decimal Carbs { get; set; }

        [Range(0, 1000, ErrorMessage = "Время приготовления должно быть от 0 до 1000 минут.")]
        [Display(Name = "Время приготовления, мин.")]
        public int CookingTime { get; set; }

        [StringLength(100, ErrorMessage = "Основной ингредиент не должен быть длиннее 100 символов.")]
        [Display(Name = "Основной ингредиент")]
        public string? MainIngredient { get; set; }

        [Required(ErrorMessage = "Введите список ингредиентов.")]
        [Display(Name = "Список ингредиентов")]
        public string IngredientsList { get; set; } = string.Empty;

        [Display(Name = "Подходит детям")]
        public bool IsForChildren { get; set; }

        [Display(Name = "Типы питания")]
        public List<int> SelectedDietTypeIds { get; set; } = new();

        [Display(Name = "Аллергены")]
        public List<int> SelectedAllergenIds { get; set; } = new();

        public List<FilterOptionViewModel> Categories { get; set; } = new();

        public List<FilterOptionViewModel> DietTypes { get; set; } = new();

        public List<FilterOptionViewModel> Allergens { get; set; } = new();
    }
}
