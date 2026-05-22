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
        }
    }
}