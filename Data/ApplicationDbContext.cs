using Microsoft.EntityFrameworkCore;
using SmartMeal.Models;

namespace SmartMeal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<DishAllergen> DishAllergens { get; set; }
        public DbSet<DietType> DietTypes { get; set; }
        public DbSet<DishDietType> DishDietTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserAllergen> UserAllergens { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Calories)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Proteins)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Fats)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Carbs)
                .HasPrecision(10, 2);

            modelBuilder.Entity<UserProfile>()
                .Property(u => u.Weight)
                .HasPrecision(6, 2);

            modelBuilder.Entity<UserProfile>()
                .Property(u => u.Height)
                .HasPrecision(6, 2);

            modelBuilder.Entity<UserProfile>()
                .Property(u => u.DailyCalories)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DishAllergen>()
                .HasKey(da => new { da.DishId, da.AllergenId });

            modelBuilder.Entity<DishAllergen>()
                .HasOne(da => da.Dish)
                .WithMany(d => d.DishAllergens)
                .HasForeignKey(da => da.DishId);

            modelBuilder.Entity<DishAllergen>()
                .HasOne(da => da.Allergen)
                .WithMany(a => a.DishAllergens)
                .HasForeignKey(da => da.AllergenId);

            modelBuilder.Entity<DishDietType>()
                .HasKey(dd => new { dd.DishId, dd.DietTypeId });

            modelBuilder.Entity<DishDietType>()
                .HasOne(dd => dd.Dish)
                .WithMany(d => d.DishDietTypes)
                .HasForeignKey(dd => dd.DishId);

            modelBuilder.Entity<DishDietType>()
                .HasOne(dd => dd.DietType)
                .WithMany(dt => dt.DishDietTypes)
                .HasForeignKey(dd => dd.DietTypeId);

            modelBuilder.Entity<UserAllergen>()
                .HasKey(ua => new { ua.UserProfileId, ua.AllergenId });

            modelBuilder.Entity<UserAllergen>()
                .HasOne(ua => ua.UserProfile)
                .WithMany(u => u.UserAllergens)
                .HasForeignKey(ua => ua.UserProfileId);

            modelBuilder.Entity<UserAllergen>()
                .HasOne(ua => ua.Allergen)
                .WithMany(a => a.UserAllergens)
                .HasForeignKey(ua => ua.AllergenId);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.CreatedByUserProfile)
                .WithMany(u => u.CustomDishes)
                .HasForeignKey(d => d.CreatedByUserProfileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Завтрак", SortOrder = 1 },
                new Category { Id = 2, Name = "Обед", SortOrder = 2 },
                new Category { Id = 3, Name = "Ужин", SortOrder = 3 },
                new Category { Id = 4, Name = "Перекус", SortOrder = 4 }
);

            modelBuilder.Entity<DietType>().HasData(
                new DietType { Id = 1, Name = "Высокобелковая", Description = "Рацион с повышенным содержанием белка." },
                new DietType { Id = 2, Name = "Без глютена", Description = "Рацион без продуктов, содержащих глютен." },
                new DietType { Id = 3, Name = "Вегетарианская", Description = "Рацион без мясных продуктов." },
                new DietType { Id = 4, Name = "Кето", Description = "Рацион с низким содержанием углеводов и высоким содержанием жиров." },
                new DietType { Id = 5, Name = "Низкокалорийная", Description = "Рацион с пониженной калорийностью." },
                new DietType { Id = 6, Name = "Низкоуглеводная", Description = "Рацион с ограничением углеводов." },
                new DietType { Id = 7, Name = "Правильное питание", Description = "Сбалансированный рацион для здорового питания." }
            );

            modelBuilder.Entity<Allergen>().HasData(
                new Allergen { Id = 1, Name = "Молоко", Description = "Молочные продукты и лактоза." },
                new Allergen { Id = 2, Name = "Орехи", Description = "Орехи и продукты, которые могут содержать следы орехов." },
                new Allergen { Id = 3, Name = "Цитрусовые", Description = "Апельсины, лимоны, мандарины и другие цитрусовые." },
                new Allergen { Id = 4, Name = "Глютен", Description = "Пшеница, рожь, ячмень и продукты с глютеном." },
                new Allergen { Id = 5, Name = "Яйца", Description = "Куриные яйца и продукты с их содержанием." },
                new Allergen { Id = 6, Name = "Рыба", Description = "Рыба и рыбные продукты." },
                new Allergen { Id = 7, Name = "Морепродукты", Description = "Креветки, мидии, кальмары и другие морепродукты." },
                new Allergen { Id = 8, Name = "Соя", Description = "Соя и соевые продукты." }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Овсяная каша с яблоком",
                    Description = "Теплая овсяная каша на завтрак с кусочками яблока и корицей.",
                    CategoryId = 1,
                    Calories = 310m,
                    Proteins = 9m,
                    Fats = 7m,
                    Carbs = 54m,
                    CookingTime = 15,
                    IngredientsList = "Овсяные хлопья, молоко, яблоко, корица, мед",
                    MainIngredient = "Овсяные хлопья",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 2,
                    Name = "Творожная запеканка",
                    Description = "Нежная запеканка из творога с легкой сладостью и мягкой текстурой.",
                    CategoryId = 1,
                    Calories = 360m,
                    Proteins = 24m,
                    Fats = 14m,
                    Carbs = 34m,
                    CookingTime = 45,
                    IngredientsList = "Творог, яйцо, манная крупа, сметана, сахар",
                    MainIngredient = "Творог",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 3,
                    Name = "Куриный суп с овощами",
                    Description = "Легкий обеденный суп с курицей, картофелем, морковью и зеленью.",
                    CategoryId = 2,
                    Calories = 280m,
                    Proteins = 22m,
                    Fats = 8m,
                    Carbs = 30m,
                    CookingTime = 50,
                    IngredientsList = "Куриное филе, картофель, морковь, лук, зелень",
                    MainIngredient = "Курица",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 4,
                    Name = "Гречка с индейкой",
                    Description = "Сытное блюдо для обеда из рассыпчатой гречки и тушеной индейки.",
                    CategoryId = 2,
                    Calories = 470m,
                    Proteins = 35m,
                    Fats = 12m,
                    Carbs = 55m,
                    CookingTime = 40,
                    IngredientsList = "Гречневая крупа, филе индейки, морковь, лук, растительное масло",
                    MainIngredient = "Индейка",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 5,
                    Name = "Запеченная рыба с овощами",
                    Description = "Ужин из белой рыбы, запеченной с кабачком, перцем и томатами.",
                    CategoryId = 3,
                    Calories = 390m,
                    Proteins = 32m,
                    Fats = 16m,
                    Carbs = 25m,
                    CookingTime = 35,
                    IngredientsList = "Белая рыба, кабачок, болгарский перец, томаты, лимонный сок",
                    MainIngredient = "Рыба",
                    IsForChildren = false,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 6,
                    Name = "Овощное рагу с фасолью",
                    Description = "Питательное овощное рагу с фасолью, томатами и ароматными специями.",
                    CategoryId = 3,
                    Calories = 340m,
                    Proteins = 15m,
                    Fats = 9m,
                    Carbs = 48m,
                    CookingTime = 45,
                    IngredientsList = "Фасоль, картофель, морковь, томаты, лук, специи",
                    MainIngredient = "Фасоль",
                    IsForChildren = false,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 7,
                    Name = "Йогурт с ягодами",
                    Description = "Быстрый перекус из натурального йогурта со свежими ягодами.",
                    CategoryId = 4,
                    Calories = 190m,
                    Proteins = 10m,
                    Fats = 5m,
                    Carbs = 26m,
                    CookingTime = 5,
                    IngredientsList = "Натуральный йогурт, ягоды, овсяные хлопья",
                    MainIngredient = "Йогурт",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 8,
                    Name = "Сэндвич с курицей",
                    Description = "Простой перекус с куриным филе, овощами и цельнозерновым хлебом.",
                    CategoryId = 4,
                    Calories = 330m,
                    Proteins = 24m,
                    Fats = 10m,
                    Carbs = 35m,
                    CookingTime = 10,
                    IngredientsList = "Цельнозерновой хлеб, куриное филе, огурец, лист салата, йогуртовый соус",
                    MainIngredient = "Курица",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                }
            );

            modelBuilder.Entity<DishDietType>().HasData(
                new DishDietType { DishId = 1, DietTypeId = 5 },
                new DishDietType { DishId = 1, DietTypeId = 7 },
                new DishDietType { DishId = 2, DietTypeId = 1 },
                new DishDietType { DishId = 2, DietTypeId = 7 },
                new DishDietType { DishId = 3, DietTypeId = 1 },
                new DishDietType { DishId = 3, DietTypeId = 5 },
                new DishDietType { DishId = 3, DietTypeId = 7 },
                new DishDietType { DishId = 4, DietTypeId = 1 },
                new DishDietType { DishId = 4, DietTypeId = 7 },
                new DishDietType { DishId = 5, DietTypeId = 1 },
                new DishDietType { DishId = 5, DietTypeId = 6 },
                new DishDietType { DishId = 5, DietTypeId = 7 },
                new DishDietType { DishId = 6, DietTypeId = 3 },
                new DishDietType { DishId = 6, DietTypeId = 5 },
                new DishDietType { DishId = 6, DietTypeId = 7 },
                new DishDietType { DishId = 7, DietTypeId = 5 },
                new DishDietType { DishId = 7, DietTypeId = 7 },
                new DishDietType { DishId = 8, DietTypeId = 1 },
                new DishDietType { DishId = 8, DietTypeId = 7 }
            );

            modelBuilder.Entity<DishAllergen>().HasData(
                new DishAllergen { DishId = 1, AllergenId = 1 },
                new DishAllergen { DishId = 1, AllergenId = 4 },
                new DishAllergen { DishId = 2, AllergenId = 1 },
                new DishAllergen { DishId = 2, AllergenId = 5 },
                new DishAllergen { DishId = 2, AllergenId = 4 },
                new DishAllergen { DishId = 5, AllergenId = 6 },
                new DishAllergen { DishId = 5, AllergenId = 3 },
                new DishAllergen { DishId = 7, AllergenId = 1 },
                new DishAllergen { DishId = 8, AllergenId = 4 },
                new DishAllergen { DishId = 8, AllergenId = 1 }
            );
        }
    }
}
