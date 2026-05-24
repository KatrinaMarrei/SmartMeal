using System.ComponentModel.DataAnnotations;

namespace SmartMeal.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО.")]
        [StringLength(150, ErrorMessage = "ФИО не должно быть длиннее 150 символов.")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите email.")]
        [EmailAddress(ErrorMessage = "Введите корректный email.")]
        [StringLength(150, ErrorMessage = "Email не должен быть длиннее 150 символов.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Пол не должен быть длиннее 20 символов.")]
        [Display(Name = "Пол")]
        public string? Gender { get; set; }

        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120 лет.")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Range(1, 300, ErrorMessage = "Вес должен быть от 1 до 300 кг.")]
        [Display(Name = "Вес, кг")]
        public decimal Weight { get; set; }

        [Range(1, 250, ErrorMessage = "Рост должен быть от 1 до 250 см.")]
        [Display(Name = "Рост, см")]
        public decimal Height { get; set; }

        [StringLength(100, ErrorMessage = "Цель не должна быть длиннее 100 символов.")]
        [Display(Name = "Цель")]
        public string? Goal { get; set; }

        [Range(1, 5, ErrorMessage = "Уровень активности должен быть от 1 до 5.")]
        [Display(Name = "Уровень активности")]
        public int ActivityLevel { get; set; }

        [Range(0, 10000, ErrorMessage = "Дневная норма калорий должна быть от 0 до 10000.")]
        [Display(Name = "Дневная норма калорий")]
        public decimal DailyCalories { get; set; }

        [Display(Name = "Аллергены")]
        public List<int> SelectedAllergenIds { get; set; } = new();

        public List<FilterOptionViewModel> Allergens { get; set; } = new();
    }
}
