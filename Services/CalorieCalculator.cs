namespace SmartMeal.Services
{
    public static class CalorieCalculator
    {
        private static readonly IReadOnlyDictionary<int, decimal> ActivityFactors = new Dictionary<int, decimal>
        {
            [1] = 1.2m,
            [2] = 1.375m,
            [3] = 1.55m,
            [4] = 1.725m,
            [5] = 1.9m
        };

        private static readonly IReadOnlyDictionary<string, decimal> GoalAdjustments = new Dictionary<string, decimal>
        {
            ["Снижение веса"] = -500m,
            ["Поддержание веса"] = 0m,
            ["Набор массы"] = 300m
        };

        public static bool TryCalculate(
            string? gender,
            int age,
            decimal weightKg,
            decimal heightCm,
            int activityLevel,
            string? goal,
            out decimal dailyCalories)
        {
            dailyCalories = 0m;

            if (age <= 0 || weightKg <= 0 || heightCm <= 0)
            {
                return false;
            }

            if (!ActivityFactors.TryGetValue(activityLevel, out var activityFactor))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(goal) || !GoalAdjustments.TryGetValue(goal, out var goalAdjustment))
            {
                return false;
            }

            var bmr = gender switch
            {
                "Мужской" => 10m * weightKg + 6.25m * heightCm - 5m * age + 5m,
                "Женский" => 10m * weightKg + 6.25m * heightCm - 5m * age - 161m,
                _ => 0m
            };

            if (bmr <= 0m)
            {
                return false;
            }

            dailyCalories = Math.Round(bmr * activityFactor + goalAdjustment, 0);

            return dailyCalories > 0m;
        }
    }
}
