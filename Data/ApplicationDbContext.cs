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
        }
    }
}