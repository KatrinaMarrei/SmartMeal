using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMeal.Migrations
{
    /// <inheritdoc />
    public partial class ExpandRecipeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DishAllergens",
                columns: new[] { "AllergenId", "DishId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "DishDietTypes",
                columns: new[] { "DietTypeId", "DishId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 5, 5 },
                    { 2, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Сварите овсяные хлопья на молоке с щепоткой соли. 2. Добавьте нарезанное яблоко, корицу и мед. 3. Прогрейте 2 минуты и подавайте теплой.", "Овсяные хлопья 50 г, молоко 2,5% 180 мл, яблоко 100 г, мед 8 г, корица 1 г, соль 1 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Смешайте творог, яйцо, манку, сметану и сахар. 2. Переложите массу в форму. 3. Запекайте при 180 градусах около 35 минут.", "Творог 5% 180 г, яйцо 1 шт., манная крупа 20 г, сметана 10% 25 г, сахар 12 г, ванилин 1 г, соль 1 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Отварите куриное филе до готовности. 2. Добавьте картофель, морковь и лук. 3. Варите до мягкости овощей, посолите и посыпьте зеленью.", "Куриное филе 100 г, картофель 120 г, морковь 50 г, лук 35 г, зелень 5 г, соль 2 г, лавровый лист 1 шт." });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Отварите гречку до рассыпчатости. 2. Потушите индейку с луком и морковью на масле. 3. Соедините с крупой и прогрейте под крышкой.", "Гречневая крупа 70 г, филе индейки 130 г, морковь 50 г, лук 40 г, растительное масло 8 г, соль 2 г, черный перец 1 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Выложите рыбу в форму и сбрызните лимонным соком. 2. Добавьте кабачок, перец и томаты. 3. Запекайте при 190 градусах 25 минут.", "Филе белой рыбы 160 г, кабачок 120 г, болгарский перец 80 г, томаты 100 г, оливковое масло 10 г, лимонный сок 10 мл, соль 2 г, укроп 5 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Обжарьте лук и морковь на масле. 2. Добавьте картофель, томаты, фасоль и специи. 3. Тушите до мягкости овощей.", "Фасоль отварная 120 г, картофель 100 г, морковь 60 г, томаты 120 г, лук 40 г, растительное масло 8 г, соль 2 г, паприка 2 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Выложите натуральный йогурт в чашку. 2. Добавьте ягоды и овсяные хлопья. 3. Перемешайте и подавайте сразу.", "Натуральный йогурт 2,5% 150 г, ягоды 80 г, овсяные хлопья 15 г, мед 5 г" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "1. Подсушите хлеб. 2. Выложите курицу, огурец, салат и йогуртовый соус. 3. Накройте вторым ломтиком и разрежьте пополам.", "Цельнозерновой хлеб 70 г, куриное филе готовое 80 г, огурец 50 г, лист салата 10 г, йогурт 25 г, горчица 3 г, соль 1 г" });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbs", "CategoryId", "CookingTime", "CreatedByUserProfileId", "Description", "Fats", "ImageUrl", "IngredientsList", "IsCustom", "IsForChildren", "MainIngredient", "Name", "Proteins" },
                values: new object[,]
                {
                    { 9, 330m, 5m, 1, 12, null, "1. Взбейте яйца с молоком и солью. 2. Прогрейте шпинат на сковороде с маслом. 3. Залейте яйцами, посыпьте сыром и готовьте под крышкой.", 24m, null, "Яйца 2 шт., молоко 40 мл, шпинат 60 г, твердый сыр 25 г, сливочное масло 5 г, соль 1 г, черный перец 1 г", false, true, "Яйца", "Омлет со шпинатом и сыром", 24m },
                    { 10, 290m, 23m, 1, 5, null, "1. Переложите йогурт в миску. 2. Добавьте орехи, ягоды и мед. 3. Посыпьте семенами чиа и подавайте охлажденным.", 14m, null, "Греческий йогурт 170 г, грецкие орехи 15 г, ягоды 60 г, мед 8 г, семена чиа 5 г", false, true, "Греческий йогурт", "Греческий йогурт с орехами", 20m },
                    { 11, 340m, 30m, 1, 25, null, "1. Смешайте творог, яйцо, рисовую муку и немного сахара. 2. Сформируйте сырники. 3. Обжарьте на минимуме масла до румяной корочки.", 13m, null, "Творог 5% 180 г, яйцо 1 шт., рисовая мука 25 г, сахар 8 г, растительное масло 5 г, соль 1 г", false, true, "Творог", "Сырники из рисовой муки", 25m },
                    { 12, 360m, 9m, 1, 20, null, "1. Разрежьте авокадо и выньте часть мякоти. 2. Взбейте яйцо, добавьте томаты и специи. 3. Запекайте при 180 градусах до готовности яйца.", 31m, null, "Авокадо 120 г, яйцо 1 шт., томаты черри 70 г, оливковое масло 5 г, соль 1 г, черный перец 1 г, зелень 5 г", false, false, "Авокадо", "Авокадо с яйцом и томатами", 14m },
                    { 13, 300m, 52m, 1, 30, null, "1. Нарежьте тыкву кубиками и потушите с водой. 2. Добавьте рис, молоко и соль. 3. Варите до мягкости, затем добавьте масло.", 7m, null, "Рис 50 г, тыква 120 г, молоко 180 мл, сливочное масло 5 г, сахар 8 г, соль 1 г", false, true, "Тыква", "Рисовая каша с тыквой", 8m },
                    { 14, 510m, 58m, 2, 35, null, "1. Обжарьте курицу с луком на масле. 2. Добавьте булгур, морковь, перец и воду. 3. Тушите под крышкой до готовности крупы.", 13m, null, "Булгур 75 г, куриное филе 140 г, морковь 50 г, болгарский перец 70 г, лук 35 г, оливковое масло 8 г, соль 2 г, паприка 2 г", false, true, "Курица", "Булгур с курицей и овощами", 38m },
                    { 15, 320m, 46m, 2, 35, null, "1. Промойте чечевицу. 2. Варите ее с томатами, морковью и луком. 3. Добавьте специи, пробейте часть супа блендером и подавайте.", 7m, null, "Красная чечевица 70 г, томаты 150 г, морковь 60 г, лук 40 г, оливковое масло 6 г, соль 2 г, зира 1 г, зелень 5 г", false, false, "Чечевица", "Чечевичный суп с томатами", 18m },
                    { 16, 520m, 62m, 2, 25, null, "1. Отварите пасту до готовности. 2. Прогрейте томаты с тунцом и чесноком. 3. Соедините пасту с соусом и посыпьте зеленью.", 14m, null, "Паста из твердых сортов 80 г, тунец консервированный 100 г, томаты 150 г, оливковое масло 8 г, чеснок 5 г, соль 2 г, базилик 2 г", false, false, "Тунец", "Паста с тунцом и томатами", 34m },
                    { 17, 460m, 58m, 2, 30, null, "1. Отварите киноа. 2. Добавьте нут, огурец, томаты и зелень. 3. Заправьте маслом, лимонным соком и специями.", 16m, null, "Киноа 65 г, нут отварной 100 г, огурец 80 г, томаты 100 г, оливковое масло 10 г, лимонный сок 10 мл, соль 2 г, петрушка 5 г", false, false, "Киноа", "Боул с киноа и нутом", 17m },
                    { 18, 480m, 50m, 2, 45, null, "1. Смешайте фарш индейки с рисом, яйцом и солью. 2. Сформируйте тефтели. 3. Тушите в томатном соусе до готовности.", 14m, null, "Фарш индейки 150 г, рис отварной 120 г, яйцо 0,5 шт., томатный соус 120 г, лук 35 г, растительное масло 5 г, соль 2 г", false, true, "Индейка", "Тефтели из индейки с рисом", 36m },
                    { 19, 410m, 36m, 2, 80, null, "1. Отварите говядину до мягкости. 2. Добавьте свеклу, капусту, картофель и морковь. 3. Варите до готовности и подавайте со сметаной.", 17m, null, "Говядина 120 г, свекла 100 г, капуста 90 г, картофель 100 г, морковь 50 г, лук 35 г, сметана 20 г, соль 2 г", false, true, "Говядина", "Борщ с говядиной", 28m },
                    { 20, 430m, 55m, 2, 25, null, "1. Отварите рис. 2. Быстро обжарьте креветки с овощами и соевым соусом. 3. Добавьте рис и прогрейте все вместе.", 10m, null, "Рис 70 г, креветки очищенные 140 г, зеленый горошек 50 г, морковь 50 г, соевый соус 10 мл, кунжутное масло 6 г, соль 1 г", false, false, "Креветки", "Рис с креветками и овощами", 30m },
                    { 21, 360m, 12m, 3, 30, null, "1. Приправьте куриную грудку солью и специями. 2. Запеките вместе с брокколи и маслом. 3. Дайте мясу отдохнуть 5 минут перед подачей.", 15m, null, "Куриная грудка 170 г, брокколи 180 г, оливковое масло 10 г, соль 2 г, паприка 2 г, чеснок сушеный 1 г", false, true, "Курица", "Куриная грудка с брокколи", 42m },
                    { 22, 450m, 12m, 3, 40, null, "1. Обжарьте ломтики говядины на масле. 2. Добавьте цветную капусту и специи. 3. Тушите до мягкости мяса и овощей.", 28m, null, "Говядина 160 г, цветная капуста 200 г, сливочное масло 10 г, оливковое масло 5 г, соль 2 г, черный перец 1 г", false, false, "Говядина", "Говядина с цветной капустой", 35m },
                    { 23, 380m, 11m, 3, 25, null, "1. Обжарьте кабачок, перец и шпинат. 2. Залейте яйцами с сыром. 3. Доведите до готовности на сковороде или в духовке.", 27m, null, "Яйца 3 шт., кабачок 80 г, болгарский перец 70 г, шпинат 40 г, сыр 30 г, оливковое масло 8 г, соль 2 г", false, true, "Яйца", "Фриттата с овощами", 24m },
                    { 24, 350m, 18m, 3, 20, null, "1. Нарежьте тофу и овощи. 2. Обжарьте их с имбирем и соевым соусом. 3. Посыпьте кунжутом и подавайте горячим.", 20m, null, "Тофу 180 г, брокколи 100 г, болгарский перец 80 г, соевый соус 15 мл, кунжутное масло 8 г, имбирь 5 г, кунжут 5 г", false, false, "Тофу", "Тофу с овощами в соевом соусе", 22m },
                    { 25, 470m, 9m, 3, 30, null, "1. Измельчите лосось с яйцом и зеленью. 2. Сформируйте котлеты и обжарьте на масле. 3. Подайте с салатом из огурца и зелени.", 31m, null, "Филе лосося 160 г, яйцо 0,5 шт., огурец 100 г, листовой салат 50 г, оливковое масло 10 г, лимонный сок 8 мл, соль 2 г", false, false, "Лосось", "Котлеты из лосося с салатом", 34m },
                    { 26, 330m, 54m, 3, 50, null, "1. Смешайте отварной рис с овощами и томатами. 2. Наполните перец начинкой. 3. Тушите в томатном соусе до мягкости.", 9m, null, "Болгарский перец 180 г, рис отварной 130 г, морковь 60 г, лук 40 г, томатный соус 120 г, растительное масло 7 г, соль 2 г", false, true, "Болгарский перец", "Перец, фаршированный овощами и рисом", 10m },
                    { 27, 390m, 24m, 3, 25, null, "1. Быстро обжарьте куриную печень с луком. 2. Добавьте яблоко и листья салата. 3. Заправьте маслом и бальзамическим уксусом.", 20m, null, "Куриная печень 160 г, яблоко 90 г, листовой салат 60 г, лук 35 г, оливковое масло 10 г, бальзамический уксус 8 мл, соль 2 г", false, false, "Куриная печень", "Теплый салат с печенью и яблоком", 29m },
                    { 28, 220m, 24m, 4, 10, null, "1. Нарежьте морковь, огурец и перец брусочками. 2. Смешайте хумус с лимонным соком и паприкой. 3. Подавайте овощи с соусом.", 11m, null, "Хумус 70 г, морковь 70 г, огурец 80 г, болгарский перец 80 г, лимонный сок 5 мл, паприка 1 г", false, true, "Хумус", "Овощные палочки с хумусом", 8m },
                    { 29, 210m, 27m, 4, 5, null, "1. Нарежьте яблоко дольками. 2. Смажьте арахисовой пастой. 3. Посыпьте корицей и подавайте сразу.", 10m, null, "Яблоко 150 г, арахисовая паста 18 г, корица 1 г", false, true, "Яблоко", "Яблоко с арахисовой пастой", 5m },
                    { 30, 240m, 12m, 4, 5, null, "1. Смешайте творог с какао и йогуртом. 2. Добавьте подсластитель по вкусу. 3. Охладите 5 минут и подавайте.", 8m, null, "Творог 2% 180 г, натуральный йогурт 40 г, какао 5 г, подсластитель 1 г, ванилин 1 г", false, false, "Творог", "Протеиновый творог с какао", 30m },
                    { 31, 230m, 24m, 4, 7, null, "1. Разомните авокадо с лимонным соком и солью. 2. Намажьте массу на рисовые хлебцы. 3. Добавьте томаты и зелень.", 14m, null, "Рисовые хлебцы 25 г, авокадо 80 г, томаты черри 60 г, лимонный сок 5 мл, соль 1 г, зелень 5 г", false, false, "Авокадо", "Рисовые хлебцы с авокадо", 4m },
                    { 32, 260m, 42m, 4, 5, null, "1. Нарежьте банан. 2. Взбейте его с кефиром, ягодами и овсяными хлопьями. 3. Подавайте сразу после приготовления.", 6m, null, "Кефир 1% 200 мл, банан 90 г, ягоды 60 г, овсяные хлопья 15 г, мед 5 г", false, true, "Кефир", "Смузи с кефиром и бананом", 11m }
                });

            migrationBuilder.InsertData(
                table: "DishAllergens",
                columns: new[] { "AllergenId", "DishId" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 1, 11 },
                    { 5, 11 },
                    { 3, 12 },
                    { 5, 12 },
                    { 1, 13 },
                    { 4, 14 },
                    { 4, 16 },
                    { 6, 16 },
                    { 5, 18 },
                    { 1, 19 },
                    { 7, 20 },
                    { 8, 20 },
                    { 1, 23 },
                    { 5, 23 },
                    { 8, 24 },
                    { 3, 25 },
                    { 5, 25 },
                    { 6, 25 },
                    { 2, 29 },
                    { 1, 30 },
                    { 3, 31 },
                    { 1, 32 },
                    { 4, 32 }
                });

            migrationBuilder.InsertData(
                table: "DishDietTypes",
                columns: new[] { "DietTypeId", "DishId" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 2, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 6, 9 },
                    { 7, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 7, 10 },
                    { 1, 11 },
                    { 2, 11 },
                    { 3, 11 },
                    { 7, 11 },
                    { 2, 12 },
                    { 3, 12 },
                    { 4, 12 },
                    { 6, 12 },
                    { 7, 12 },
                    { 3, 13 },
                    { 7, 13 },
                    { 1, 14 },
                    { 7, 14 },
                    { 2, 15 },
                    { 3, 15 },
                    { 5, 15 },
                    { 7, 15 },
                    { 1, 16 },
                    { 7, 16 },
                    { 2, 17 },
                    { 3, 17 },
                    { 7, 17 },
                    { 1, 18 },
                    { 7, 18 },
                    { 1, 19 },
                    { 7, 19 },
                    { 1, 20 },
                    { 2, 20 },
                    { 7, 20 },
                    { 1, 21 },
                    { 2, 21 },
                    { 5, 21 },
                    { 6, 21 },
                    { 7, 21 },
                    { 1, 22 },
                    { 2, 22 },
                    { 4, 22 },
                    { 6, 22 },
                    { 1, 23 },
                    { 2, 23 },
                    { 3, 23 },
                    { 4, 23 },
                    { 6, 23 },
                    { 7, 23 },
                    { 2, 24 },
                    { 3, 24 },
                    { 5, 24 },
                    { 6, 24 },
                    { 7, 24 },
                    { 1, 25 },
                    { 2, 25 },
                    { 4, 25 },
                    { 6, 25 },
                    { 7, 25 },
                    { 2, 26 },
                    { 3, 26 },
                    { 5, 26 },
                    { 7, 26 },
                    { 1, 27 },
                    { 2, 27 },
                    { 7, 27 },
                    { 2, 28 },
                    { 3, 28 },
                    { 5, 28 },
                    { 7, 28 },
                    { 2, 29 },
                    { 3, 29 },
                    { 5, 29 },
                    { 7, 29 },
                    { 1, 30 },
                    { 2, 30 },
                    { 3, 30 },
                    { 5, 30 },
                    { 6, 30 },
                    { 7, 30 },
                    { 2, 31 },
                    { 3, 31 },
                    { 5, 31 },
                    { 7, 31 },
                    { 5, 32 },
                    { 7, 32 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 18 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 8, 24 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 2, 29 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "DishAllergens",
                keyColumns: new[] { "AllergenId", "DishId" },
                keyValues: new object[] { 4, 32 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 14 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 17 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 21 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 23 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 24 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 25 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 26 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 27 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 28 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 28 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 28 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 29 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 29 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 29 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 6, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 30 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 2, 31 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 31 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 31 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 5, 32 });

            migrationBuilder.DeleteData(
                table: "DishDietTypes",
                keyColumns: new[] { "DietTypeId", "DishId" },
                keyValues: new object[] { 7, 32 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Теплая овсяная каша на завтрак с кусочками яблока и корицей.", "Овсяные хлопья, молоко, яблоко, корица, мед" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Нежная запеканка из творога с легкой сладостью и мягкой текстурой.", "Творог, яйцо, манная крупа, сметана, сахар" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Легкий обеденный суп с курицей, картофелем, морковью и зеленью.", "Куриное филе, картофель, морковь, лук, зелень" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Сытное блюдо для обеда из рассыпчатой гречки и тушеной индейки.", "Гречневая крупа, филе индейки, морковь, лук, растительное масло" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Ужин из белой рыбы, запеченной с кабачком, перцем и томатами.", "Белая рыба, кабачок, болгарский перец, томаты, лимонный сок" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Питательное овощное рагу с фасолью, томатами и ароматными специями.", "Фасоль, картофель, морковь, томаты, лук, специи" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Быстрый перекус из натурального йогурта со свежими ягодами.", "Натуральный йогурт, ягоды, овсяные хлопья" });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "IngredientsList" },
                values: new object[] { "Простой перекус с куриным филе, овощами и цельнозерновым хлебом.", "Цельнозерновой хлеб, куриное филе, огурец, лист салата, йогуртовый соус" });
        }
    }
}
