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
        public DbSet<FavoriteDish> FavoriteDishes { get; set; }

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

            modelBuilder.Entity<FavoriteDish>()
                .HasKey(fd => new { fd.UserProfileId, fd.DishId });

            modelBuilder.Entity<FavoriteDish>()
                .HasOne(fd => fd.UserProfile)
                .WithMany(u => u.FavoriteDishes)
                .HasForeignKey(fd => fd.UserProfileId);

            modelBuilder.Entity<FavoriteDish>()
                .HasOne(fd => fd.Dish)
                .WithMany(d => d.FavoriteDishes)
                .HasForeignKey(fd => fd.DishId);

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

            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    Id = 1,
                    FullName = "Демо-пользователь",
                    Email = "demo@smartmeal.local",
                    Gender = "Женский",
                    Age = 22,
                    Weight = 65m,
                    Height = 170m,
                    Goal = "Поддержание веса",
                    ActivityLevel = 3,
                    DailyCalories = 2000
                }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Овсяная каша с яблоком",
                    Description = "1. Сварите овсяные хлопья на молоке с щепоткой соли. 2. Добавьте нарезанное яблоко, корицу и мед. 3. Прогрейте 2 минуты и подавайте теплой.",
                    CategoryId = 1,
                    Calories = 310m,
                    Proteins = 9m,
                    Fats = 7m,
                    Carbs = 54m,
                    CookingTime = 15,
                    ImageUrl = null,
                    IngredientsList = "Овсяные хлопья 50 г, молоко 2,5% 180 мл, яблоко 100 г, мед 8 г, корица 1 г, соль 1 г",
                    MainIngredient = "Овсяные хлопья",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 2,
                    Name = "Творожная запеканка",
                    Description = "1. Смешайте творог, яйцо, манку, сметану и сахар. 2. Переложите массу в форму. 3. Запекайте при 180 градусах около 35 минут.",
                    CategoryId = 1,
                    Calories = 360m,
                    Proteins = 24m,
                    Fats = 14m,
                    Carbs = 34m,
                    CookingTime = 45,
                    ImageUrl = null,
                    IngredientsList = "Творог 5% 180 г, яйцо 1 шт., манная крупа 20 г, сметана 10% 25 г, сахар 12 г, ванилин 1 г, соль 1 г",
                    MainIngredient = "Творог",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 3,
                    Name = "Куриный суп с овощами",
                    Description = "1. Отварите куриное филе до готовности. 2. Добавьте картофель, морковь и лук. 3. Варите до мягкости овощей, посолите и посыпьте зеленью.",
                    CategoryId = 2,
                    Calories = 280m,
                    Proteins = 22m,
                    Fats = 8m,
                    Carbs = 30m,
                    CookingTime = 50,
                    ImageUrl = null,
                    IngredientsList = "Куриное филе 100 г, картофель 120 г, морковь 50 г, лук 35 г, зелень 5 г, соль 2 г, лавровый лист 1 шт.",
                    MainIngredient = "Курица",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 4,
                    Name = "Гречка с индейкой",
                    Description = "1. Отварите гречку до рассыпчатости. 2. Потушите индейку с луком и морковью на масле. 3. Соедините с крупой и прогрейте под крышкой.",
                    CategoryId = 2,
                    Calories = 470m,
                    Proteins = 35m,
                    Fats = 12m,
                    Carbs = 55m,
                    CookingTime = 40,
                    ImageUrl = null,
                    IngredientsList = "Гречневая крупа 70 г, филе индейки 130 г, морковь 50 г, лук 40 г, растительное масло 8 г, соль 2 г, черный перец 1 г",
                    MainIngredient = "Индейка",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 5,
                    Name = "Запеченная рыба с овощами",
                    Description = "1. Выложите рыбу в форму и сбрызните лимонным соком. 2. Добавьте кабачок, перец и томаты. 3. Запекайте при 190 градусах 25 минут.",
                    CategoryId = 3,
                    Calories = 390m,
                    Proteins = 32m,
                    Fats = 16m,
                    Carbs = 25m,
                    CookingTime = 35,
                    ImageUrl = null,
                    IngredientsList = "Филе белой рыбы 160 г, кабачок 120 г, болгарский перец 80 г, томаты 100 г, оливковое масло 10 г, лимонный сок 10 мл, соль 2 г, укроп 5 г",
                    MainIngredient = "Рыба",
                    IsForChildren = false,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 6,
                    Name = "Овощное рагу с фасолью",
                    Description = "1. Обжарьте лук и морковь на масле. 2. Добавьте картофель, томаты, фасоль и специи. 3. Тушите до мягкости овощей.",
                    CategoryId = 3,
                    Calories = 340m,
                    Proteins = 15m,
                    Fats = 9m,
                    Carbs = 48m,
                    CookingTime = 45,
                    ImageUrl = null,
                    IngredientsList = "Фасоль отварная 120 г, картофель 100 г, морковь 60 г, томаты 120 г, лук 40 г, растительное масло 8 г, соль 2 г, паприка 2 г",
                    MainIngredient = "Фасоль",
                    IsForChildren = false,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 7,
                    Name = "Йогурт с ягодами",
                    Description = "1. Выложите натуральный йогурт в чашку. 2. Добавьте ягоды и овсяные хлопья. 3. Перемешайте и подавайте сразу.",
                    CategoryId = 4,
                    Calories = 190m,
                    Proteins = 10m,
                    Fats = 5m,
                    Carbs = 26m,
                    CookingTime = 5,
                    ImageUrl = null,
                    IngredientsList = "Натуральный йогурт 2,5% 150 г, ягоды 80 г, овсяные хлопья 15 г, мед 5 г",
                    MainIngredient = "Йогурт",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish
                {
                    Id = 8,
                    Name = "Сэндвич с курицей",
                    Description = "1. Подсушите хлеб. 2. Выложите курицу, огурец, салат и йогуртовый соус. 3. Накройте вторым ломтиком и разрежьте пополам.",
                    CategoryId = 4,
                    Calories = 330m,
                    Proteins = 24m,
                    Fats = 10m,
                    Carbs = 35m,
                    CookingTime = 10,
                    ImageUrl = null,
                    IngredientsList = "Цельнозерновой хлеб 70 г, куриное филе готовое 80 г, огурец 50 г, лист салата 10 г, йогурт 25 г, горчица 3 г, соль 1 г",
                    MainIngredient = "Курица",
                    IsForChildren = true,
                    IsCustom = false,
                    CreatedByUserProfileId = null
                },
                new Dish { Id = 9, Name = "Омлет со шпинатом и сыром", Description = "1. Взбейте яйца с молоком и солью. 2. Прогрейте шпинат на сковороде с маслом. 3. Залейте яйцами, посыпьте сыром и готовьте под крышкой.", CategoryId = 1, Calories = 330m, Proteins = 24m, Fats = 24m, Carbs = 5m, CookingTime = 12, ImageUrl = null, IngredientsList = "Яйца 2 шт., молоко 40 мл, шпинат 60 г, твердый сыр 25 г, сливочное масло 5 г, соль 1 г, черный перец 1 г", MainIngredient = "Яйца", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 10, Name = "Греческий йогурт с орехами", Description = "1. Переложите йогурт в миску. 2. Добавьте орехи, ягоды и мед. 3. Посыпьте семенами чиа и подавайте охлажденным.", CategoryId = 1, Calories = 290m, Proteins = 20m, Fats = 14m, Carbs = 23m, CookingTime = 5, ImageUrl = null, IngredientsList = "Греческий йогурт 170 г, грецкие орехи 15 г, ягоды 60 г, мед 8 г, семена чиа 5 г", MainIngredient = "Греческий йогурт", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 11, Name = "Сырники из рисовой муки", Description = "1. Смешайте творог, яйцо, рисовую муку и немного сахара. 2. Сформируйте сырники. 3. Обжарьте на минимуме масла до румяной корочки.", CategoryId = 1, Calories = 340m, Proteins = 25m, Fats = 13m, Carbs = 30m, CookingTime = 25, ImageUrl = null, IngredientsList = "Творог 5% 180 г, яйцо 1 шт., рисовая мука 25 г, сахар 8 г, растительное масло 5 г, соль 1 г", MainIngredient = "Творог", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 12, Name = "Авокадо с яйцом и томатами", Description = "1. Разрежьте авокадо и выньте часть мякоти. 2. Вбейте яйцо, добавьте томаты и специи. 3. Запекайте при 180 градусах до готовности яйца.", CategoryId = 1, Calories = 360m, Proteins = 14m, Fats = 31m, Carbs = 9m, CookingTime = 20, ImageUrl = null, IngredientsList = "Авокадо 120 г, яйцо 1 шт., томаты черри 70 г, оливковое масло 5 г, соль 1 г, черный перец 1 г, зелень 5 г", MainIngredient = "Авокадо", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 13, Name = "Рисовая каша с тыквой", Description = "1. Нарежьте тыкву кубиками и потушите с водой. 2. Добавьте рис, молоко и соль. 3. Варите до мягкости, затем добавьте масло.", CategoryId = 1, Calories = 300m, Proteins = 8m, Fats = 7m, Carbs = 52m, CookingTime = 30, ImageUrl = null, IngredientsList = "Рис 50 г, тыква 120 г, молоко 180 мл, сливочное масло 5 г, сахар 8 г, соль 1 г", MainIngredient = "Тыква", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 14, Name = "Булгур с курицей и овощами", Description = "1. Обжарьте курицу с луком на масле. 2. Добавьте булгур, морковь, перец и воду. 3. Тушите под крышкой до готовности крупы.", CategoryId = 2, Calories = 510m, Proteins = 38m, Fats = 13m, Carbs = 58m, CookingTime = 35, ImageUrl = null, IngredientsList = "Булгур 75 г, куриное филе 140 г, морковь 50 г, болгарский перец 70 г, лук 35 г, оливковое масло 8 г, соль 2 г, паприка 2 г", MainIngredient = "Курица", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 15, Name = "Чечевичный суп с томатами", Description = "1. Промойте чечевицу. 2. Варите ее с томатами, морковью и луком. 3. Добавьте специи, пробейте часть супа блендером и подавайте.", CategoryId = 2, Calories = 320m, Proteins = 18m, Fats = 7m, Carbs = 46m, CookingTime = 35, ImageUrl = null, IngredientsList = "Красная чечевица 70 г, томаты 150 г, морковь 60 г, лук 40 г, оливковое масло 6 г, соль 2 г, зира 1 г, зелень 5 г", MainIngredient = "Чечевица", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 16, Name = "Паста с тунцом и томатами", Description = "1. Отварите пасту до готовности. 2. Прогрейте томаты с тунцом и чесноком. 3. Соедините пасту с соусом и посыпьте зеленью.", CategoryId = 2, Calories = 520m, Proteins = 34m, Fats = 14m, Carbs = 62m, CookingTime = 25, ImageUrl = null, IngredientsList = "Паста из твердых сортов 80 г, тунец консервированный 100 г, томаты 150 г, оливковое масло 8 г, чеснок 5 г, соль 2 г, базилик 2 г", MainIngredient = "Тунец", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 17, Name = "Боул с киноа и нутом", Description = "1. Отварите киноа. 2. Добавьте нут, огурец, томаты и зелень. 3. Заправьте маслом, лимонным соком и специями.", CategoryId = 2, Calories = 460m, Proteins = 17m, Fats = 16m, Carbs = 58m, CookingTime = 30, ImageUrl = null, IngredientsList = "Киноа 65 г, нут отварной 100 г, огурец 80 г, томаты 100 г, оливковое масло 10 г, лимонный сок 10 мл, соль 2 г, петрушка 5 г", MainIngredient = "Киноа", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 18, Name = "Тефтели из индейки с рисом", Description = "1. Смешайте фарш индейки с рисом, яйцом и солью. 2. Сформируйте тефтели. 3. Тушите в томатном соусе до готовности.", CategoryId = 2, Calories = 480m, Proteins = 36m, Fats = 14m, Carbs = 50m, CookingTime = 45, ImageUrl = null, IngredientsList = "Фарш индейки 150 г, рис отварной 120 г, яйцо 0,5 шт., томатный соус 120 г, лук 35 г, растительное масло 5 г, соль 2 г", MainIngredient = "Индейка", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 19, Name = "Борщ с говядиной", Description = "1. Отварите говядину до мягкости. 2. Добавьте свеклу, капусту, картофель и морковь. 3. Варите до готовности и подавайте со сметаной.", CategoryId = 2, Calories = 410m, Proteins = 28m, Fats = 17m, Carbs = 36m, CookingTime = 80, ImageUrl = null, IngredientsList = "Говядина 120 г, свекла 100 г, капуста 90 г, картофель 100 г, морковь 50 г, лук 35 г, сметана 20 г, соль 2 г", MainIngredient = "Говядина", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 20, Name = "Рис с креветками и овощами", Description = "1. Отварите рис. 2. Быстро обжарьте креветки с овощами и соевым соусом. 3. Добавьте рис и прогрейте все вместе.", CategoryId = 2, Calories = 430m, Proteins = 30m, Fats = 10m, Carbs = 55m, CookingTime = 25, ImageUrl = null, IngredientsList = "Рис 70 г, креветки очищенные 140 г, зеленый горошек 50 г, морковь 50 г, соевый соус 10 мл, кунжутное масло 6 г, соль 1 г", MainIngredient = "Креветки", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 21, Name = "Куриная грудка с брокколи", Description = "1. Приправьте куриную грудку солью и специями. 2. Запеките вместе с брокколи и маслом. 3. Дайте мясу отдохнуть 5 минут перед подачей.", CategoryId = 3, Calories = 360m, Proteins = 42m, Fats = 15m, Carbs = 12m, CookingTime = 30, ImageUrl = null, IngredientsList = "Куриная грудка 170 г, брокколи 180 г, оливковое масло 10 г, соль 2 г, паприка 2 г, чеснок сушеный 1 г", MainIngredient = "Курица", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 22, Name = "Говядина с цветной капустой", Description = "1. Обжарьте ломтики говядины на масле. 2. Добавьте цветную капусту и специи. 3. Тушите до мягкости мяса и овощей.", CategoryId = 3, Calories = 450m, Proteins = 35m, Fats = 28m, Carbs = 12m, CookingTime = 40, ImageUrl = null, IngredientsList = "Говядина 160 г, цветная капуста 200 г, сливочное масло 10 г, оливковое масло 5 г, соль 2 г, черный перец 1 г", MainIngredient = "Говядина", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 23, Name = "Фриттата с овощами", Description = "1. Обжарьте кабачок, перец и шпинат. 2. Залейте яйцами с сыром. 3. Доведите до готовности на сковороде или в духовке.", CategoryId = 3, Calories = 380m, Proteins = 24m, Fats = 27m, Carbs = 11m, CookingTime = 25, ImageUrl = null, IngredientsList = "Яйца 3 шт., кабачок 80 г, болгарский перец 70 г, шпинат 40 г, сыр 30 г, оливковое масло 8 г, соль 2 г", MainIngredient = "Яйца", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 24, Name = "Тофу с овощами в соевом соусе", Description = "1. Нарежьте тофу и овощи. 2. Обжарьте их с имбирем и соевым соусом. 3. Посыпьте кунжутом и подавайте горячим.", CategoryId = 3, Calories = 350m, Proteins = 22m, Fats = 20m, Carbs = 18m, CookingTime = 20, ImageUrl = null, IngredientsList = "Тофу 180 г, брокколи 100 г, болгарский перец 80 г, соевый соус 15 мл, кунжутное масло 8 г, имбирь 5 г, кунжут 5 г", MainIngredient = "Тофу", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 25, Name = "Котлеты из лосося с салатом", Description = "1. Измельчите лосось с яйцом и зеленью. 2. Сформируйте котлеты и обжарьте на масле. 3. Подайте с салатом из огурца и зелени.", CategoryId = 3, Calories = 470m, Proteins = 34m, Fats = 31m, Carbs = 9m, CookingTime = 30, ImageUrl = null, IngredientsList = "Филе лосося 160 г, яйцо 0,5 шт., огурец 100 г, листовой салат 50 г, оливковое масло 10 г, лимонный сок 8 мл, соль 2 г", MainIngredient = "Лосось", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 26, Name = "Перец, фаршированный овощами и рисом", Description = "1. Смешайте отварной рис с овощами и томатами. 2. Наполните перец начинкой. 3. Тушите в томатном соусе до мягкости.", CategoryId = 3, Calories = 330m, Proteins = 10m, Fats = 9m, Carbs = 54m, CookingTime = 50, ImageUrl = null, IngredientsList = "Болгарский перец 180 г, рис отварной 130 г, морковь 60 г, лук 40 г, томатный соус 120 г, растительное масло 7 г, соль 2 г", MainIngredient = "Болгарский перец", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 27, Name = "Теплый салат с печенью и яблоком", Description = "1. Быстро обжарьте куриную печень с луком. 2. Добавьте яблоко и листья салата. 3. Заправьте маслом и бальзамическим уксусом.", CategoryId = 3, Calories = 390m, Proteins = 29m, Fats = 20m, Carbs = 24m, CookingTime = 25, ImageUrl = null, IngredientsList = "Куриная печень 160 г, яблоко 90 г, листовой салат 60 г, лук 35 г, оливковое масло 10 г, бальзамический уксус 8 мл, соль 2 г", MainIngredient = "Куриная печень", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 28, Name = "Овощные палочки с хумусом", Description = "1. Нарежьте морковь, огурец и перец брусочками. 2. Смешайте хумус с лимонным соком и паприкой. 3. Подавайте овощи с соусом.", CategoryId = 4, Calories = 220m, Proteins = 8m, Fats = 11m, Carbs = 24m, CookingTime = 10, ImageUrl = null, IngredientsList = "Хумус 70 г, морковь 70 г, огурец 80 г, болгарский перец 80 г, лимонный сок 5 мл, паприка 1 г", MainIngredient = "Хумус", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 29, Name = "Яблоко с арахисовой пастой", Description = "1. Нарежьте яблоко дольками. 2. Смажьте арахисовой пастой. 3. Посыпьте корицей и подавайте сразу.", CategoryId = 4, Calories = 210m, Proteins = 5m, Fats = 10m, Carbs = 27m, CookingTime = 5, ImageUrl = null, IngredientsList = "Яблоко 150 г, арахисовая паста 18 г, корица 1 г", MainIngredient = "Яблоко", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 30, Name = "Протеиновый творог с какао", Description = "1. Смешайте творог с какао и йогуртом. 2. Добавьте подсластитель по вкусу. 3. Охладите 5 минут и подавайте.", CategoryId = 4, Calories = 240m, Proteins = 30m, Fats = 8m, Carbs = 12m, CookingTime = 5, ImageUrl = null, IngredientsList = "Творог 2% 180 г, натуральный йогурт 40 г, какао 5 г, подсластитель 1 г, ванилин 1 г", MainIngredient = "Творог", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 31, Name = "Рисовые хлебцы с авокадо", Description = "1. Разомните авокадо с лимонным соком и солью. 2. Намажьте массу на рисовые хлебцы. 3. Добавьте томаты и зелень.", CategoryId = 4, Calories = 230m, Proteins = 4m, Fats = 14m, Carbs = 24m, CookingTime = 7, ImageUrl = null, IngredientsList = "Рисовые хлебцы 25 г, авокадо 80 г, томаты черри 60 г, лимонный сок 5 мл, соль 1 г, зелень 5 г", MainIngredient = "Авокадо", IsForChildren = false, IsCustom = false, CreatedByUserProfileId = null },
                new Dish { Id = 32, Name = "Смузи с кефиром и бананом", Description = "1. Нарежьте банан. 2. Взбейте его с кефиром, ягодами и овсяными хлопьями. 3. Подавайте сразу после приготовления.", CategoryId = 4, Calories = 260m, Proteins = 11m, Fats = 6m, Carbs = 42m, CookingTime = 5, ImageUrl = null, IngredientsList = "Кефир 1% 200 мл, банан 90 г, ягоды 60 г, овсяные хлопья 15 г, мед 5 г", MainIngredient = "Кефир", IsForChildren = true, IsCustom = false, CreatedByUserProfileId = null }
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
                new DishDietType { DishId = 5, DietTypeId = 2 },
                new DishDietType { DishId = 5, DietTypeId = 5 },
                new DishDietType { DishId = 5, DietTypeId = 6 },
                new DishDietType { DishId = 5, DietTypeId = 7 },
                new DishDietType { DishId = 6, DietTypeId = 2 },
                new DishDietType { DishId = 6, DietTypeId = 3 },
                new DishDietType { DishId = 6, DietTypeId = 5 },
                new DishDietType { DishId = 6, DietTypeId = 7 },
                new DishDietType { DishId = 7, DietTypeId = 5 },
                new DishDietType { DishId = 7, DietTypeId = 7 },
                new DishDietType { DishId = 8, DietTypeId = 1 },
                new DishDietType { DishId = 8, DietTypeId = 7 },
                new DishDietType { DishId = 9, DietTypeId = 1 },
                new DishDietType { DishId = 9, DietTypeId = 2 },
                new DishDietType { DishId = 9, DietTypeId = 3 },
                new DishDietType { DishId = 9, DietTypeId = 4 },
                new DishDietType { DishId = 9, DietTypeId = 6 },
                new DishDietType { DishId = 9, DietTypeId = 7 },
                new DishDietType { DishId = 10, DietTypeId = 1 },
                new DishDietType { DishId = 10, DietTypeId = 2 },
                new DishDietType { DishId = 10, DietTypeId = 3 },
                new DishDietType { DishId = 10, DietTypeId = 7 },
                new DishDietType { DishId = 11, DietTypeId = 1 },
                new DishDietType { DishId = 11, DietTypeId = 2 },
                new DishDietType { DishId = 11, DietTypeId = 3 },
                new DishDietType { DishId = 11, DietTypeId = 7 },
                new DishDietType { DishId = 12, DietTypeId = 2 },
                new DishDietType { DishId = 12, DietTypeId = 3 },
                new DishDietType { DishId = 12, DietTypeId = 4 },
                new DishDietType { DishId = 12, DietTypeId = 6 },
                new DishDietType { DishId = 12, DietTypeId = 7 },
                new DishDietType { DishId = 13, DietTypeId = 3 },
                new DishDietType { DishId = 13, DietTypeId = 7 },
                new DishDietType { DishId = 14, DietTypeId = 1 },
                new DishDietType { DishId = 14, DietTypeId = 7 },
                new DishDietType { DishId = 15, DietTypeId = 2 },
                new DishDietType { DishId = 15, DietTypeId = 3 },
                new DishDietType { DishId = 15, DietTypeId = 5 },
                new DishDietType { DishId = 15, DietTypeId = 7 },
                new DishDietType { DishId = 16, DietTypeId = 1 },
                new DishDietType { DishId = 16, DietTypeId = 7 },
                new DishDietType { DishId = 17, DietTypeId = 2 },
                new DishDietType { DishId = 17, DietTypeId = 3 },
                new DishDietType { DishId = 17, DietTypeId = 7 },
                new DishDietType { DishId = 18, DietTypeId = 1 },
                new DishDietType { DishId = 18, DietTypeId = 7 },
                new DishDietType { DishId = 19, DietTypeId = 1 },
                new DishDietType { DishId = 19, DietTypeId = 7 },
                new DishDietType { DishId = 20, DietTypeId = 1 },
                new DishDietType { DishId = 20, DietTypeId = 2 },
                new DishDietType { DishId = 20, DietTypeId = 7 },
                new DishDietType { DishId = 21, DietTypeId = 1 },
                new DishDietType { DishId = 21, DietTypeId = 2 },
                new DishDietType { DishId = 21, DietTypeId = 5 },
                new DishDietType { DishId = 21, DietTypeId = 6 },
                new DishDietType { DishId = 21, DietTypeId = 7 },
                new DishDietType { DishId = 22, DietTypeId = 1 },
                new DishDietType { DishId = 22, DietTypeId = 2 },
                new DishDietType { DishId = 22, DietTypeId = 4 },
                new DishDietType { DishId = 22, DietTypeId = 6 },
                new DishDietType { DishId = 23, DietTypeId = 1 },
                new DishDietType { DishId = 23, DietTypeId = 2 },
                new DishDietType { DishId = 23, DietTypeId = 3 },
                new DishDietType { DishId = 23, DietTypeId = 4 },
                new DishDietType { DishId = 23, DietTypeId = 6 },
                new DishDietType { DishId = 23, DietTypeId = 7 },
                new DishDietType { DishId = 24, DietTypeId = 2 },
                new DishDietType { DishId = 24, DietTypeId = 3 },
                new DishDietType { DishId = 24, DietTypeId = 5 },
                new DishDietType { DishId = 24, DietTypeId = 6 },
                new DishDietType { DishId = 24, DietTypeId = 7 },
                new DishDietType { DishId = 25, DietTypeId = 1 },
                new DishDietType { DishId = 25, DietTypeId = 2 },
                new DishDietType { DishId = 25, DietTypeId = 4 },
                new DishDietType { DishId = 25, DietTypeId = 6 },
                new DishDietType { DishId = 25, DietTypeId = 7 },
                new DishDietType { DishId = 26, DietTypeId = 2 },
                new DishDietType { DishId = 26, DietTypeId = 3 },
                new DishDietType { DishId = 26, DietTypeId = 5 },
                new DishDietType { DishId = 26, DietTypeId = 7 },
                new DishDietType { DishId = 27, DietTypeId = 1 },
                new DishDietType { DishId = 27, DietTypeId = 2 },
                new DishDietType { DishId = 27, DietTypeId = 7 },
                new DishDietType { DishId = 28, DietTypeId = 2 },
                new DishDietType { DishId = 28, DietTypeId = 3 },
                new DishDietType { DishId = 28, DietTypeId = 5 },
                new DishDietType { DishId = 28, DietTypeId = 7 },
                new DishDietType { DishId = 29, DietTypeId = 2 },
                new DishDietType { DishId = 29, DietTypeId = 3 },
                new DishDietType { DishId = 29, DietTypeId = 5 },
                new DishDietType { DishId = 29, DietTypeId = 7 },
                new DishDietType { DishId = 30, DietTypeId = 1 },
                new DishDietType { DishId = 30, DietTypeId = 2 },
                new DishDietType { DishId = 30, DietTypeId = 3 },
                new DishDietType { DishId = 30, DietTypeId = 5 },
                new DishDietType { DishId = 30, DietTypeId = 6 },
                new DishDietType { DishId = 30, DietTypeId = 7 },
                new DishDietType { DishId = 31, DietTypeId = 2 },
                new DishDietType { DishId = 31, DietTypeId = 3 },
                new DishDietType { DishId = 31, DietTypeId = 5 },
                new DishDietType { DishId = 31, DietTypeId = 7 },
                new DishDietType { DishId = 32, DietTypeId = 5 },
                new DishDietType { DishId = 32, DietTypeId = 7 }
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
                new DishAllergen { DishId = 7, AllergenId = 4 },
                new DishAllergen { DishId = 8, AllergenId = 4 },
                new DishAllergen { DishId = 8, AllergenId = 1 },
                new DishAllergen { DishId = 9, AllergenId = 1 },
                new DishAllergen { DishId = 9, AllergenId = 5 },
                new DishAllergen { DishId = 10, AllergenId = 1 },
                new DishAllergen { DishId = 10, AllergenId = 2 },
                new DishAllergen { DishId = 11, AllergenId = 1 },
                new DishAllergen { DishId = 11, AllergenId = 5 },
                new DishAllergen { DishId = 12, AllergenId = 5 },
                new DishAllergen { DishId = 12, AllergenId = 3 },
                new DishAllergen { DishId = 13, AllergenId = 1 },
                new DishAllergen { DishId = 14, AllergenId = 4 },
                new DishAllergen { DishId = 16, AllergenId = 4 },
                new DishAllergen { DishId = 16, AllergenId = 6 },
                new DishAllergen { DishId = 18, AllergenId = 5 },
                new DishAllergen { DishId = 19, AllergenId = 1 },
                new DishAllergen { DishId = 20, AllergenId = 7 },
                new DishAllergen { DishId = 20, AllergenId = 8 },
                new DishAllergen { DishId = 23, AllergenId = 1 },
                new DishAllergen { DishId = 23, AllergenId = 5 },
                new DishAllergen { DishId = 24, AllergenId = 8 },
                new DishAllergen { DishId = 25, AllergenId = 5 },
                new DishAllergen { DishId = 25, AllergenId = 6 },
                new DishAllergen { DishId = 25, AllergenId = 3 },
                new DishAllergen { DishId = 29, AllergenId = 2 },
                new DishAllergen { DishId = 30, AllergenId = 1 },
                new DishAllergen { DishId = 31, AllergenId = 3 },
                new DishAllergen { DishId = 32, AllergenId = 1 },
                new DishAllergen { DishId = 32, AllergenId = 4 }
            );
        }
    }
}
