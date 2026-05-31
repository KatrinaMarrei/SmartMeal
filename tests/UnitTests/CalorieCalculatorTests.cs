using SmartMeal.Services;

namespace UnitTests;

[TestClass]
public sealed class CalorieCalculatorTests
{
    private const string Male = "\u041c\u0443\u0436\u0441\u043a\u043e\u0439";
    private const string Female = "\u0416\u0435\u043d\u0441\u043a\u0438\u0439";
    private const string WeightLossGoal = "\u0421\u043d\u0438\u0436\u0435\u043d\u0438\u0435 \u0432\u0435\u0441\u0430";
    private const string MaintainGoal = "\u041f\u043e\u0434\u0434\u0435\u0440\u0436\u0430\u043d\u0438\u0435 \u0432\u0435\u0441\u0430";
    private const string MassGainGoal = "\u041d\u0430\u0431\u043e\u0440 \u043c\u0430\u0441\u0441\u044b";

    [TestMethod]
    public void TryCalculate_ReturnsExpectedCalories_ForValidMaleInput()
    {
        var result = CalorieCalculator.TryCalculate(
            Male,
            age: 30,
            weightKg: 80m,
            heightCm: 180m,
            activityLevel: 3,
            goal: MaintainGoal,
            out var dailyCalories);

        Assert.IsTrue(result);
        Assert.AreEqual(2759m, dailyCalories);
    }

    [TestMethod]
    public void TryCalculate_ReturnsExpectedCalories_ForValidFemaleInput()
    {
        var result = CalorieCalculator.TryCalculate(
            Female,
            age: 28,
            weightKg: 60m,
            heightCm: 165m,
            activityLevel: 2,
            goal: MaintainGoal,
            out var dailyCalories);

        Assert.IsTrue(result);
        Assert.AreEqual(1829m, dailyCalories);
    }

    [TestMethod]
    public void TryCalculate_ActivityFactorAffectsResult()
    {
        CalorieCalculator.TryCalculate(Male, 35, 75m, 178m, 1, MaintainGoal, out var lowActivityCalories);
        CalorieCalculator.TryCalculate(Male, 35, 75m, 178m, 5, MaintainGoal, out var highActivityCalories);

        Assert.IsTrue(highActivityCalories > lowActivityCalories);
    }

    [TestMethod]
    public void TryCalculate_WeightLossGoalLowersCalories()
    {
        CalorieCalculator.TryCalculate(Female, 32, 65m, 170m, 3, MaintainGoal, out var maintainCalories);
        CalorieCalculator.TryCalculate(Female, 32, 65m, 170m, 3, WeightLossGoal, out var weightLossCalories);

        Assert.AreEqual(maintainCalories - 500m, weightLossCalories);
    }

    [TestMethod]
    public void TryCalculate_MassGainGoalIncreasesCalories()
    {
        CalorieCalculator.TryCalculate(Male, 25, 70m, 175m, 3, MaintainGoal, out var maintainCalories);
        CalorieCalculator.TryCalculate(Male, 25, 70m, 175m, 3, MassGainGoal, out var massGainCalories);

        Assert.AreEqual(maintainCalories + 300m, massGainCalories);
    }

    [DataTestMethod]
    [DataRow(null, 30, 80, 180, 3, MaintainGoal)]
    [DataRow("Unsupported", 30, 80, 180, 3, MaintainGoal)]
    [DataRow(Male, 0, 80, 180, 3, MaintainGoal)]
    [DataRow(Male, 30, 0, 180, 3, MaintainGoal)]
    [DataRow(Male, 30, 80, 0, 3, MaintainGoal)]
    [DataRow(Male, 30, 80, 180, 99, MaintainGoal)]
    [DataRow(Male, 30, 80, 180, 3, null)]
    [DataRow(Male, 30, 80, 180, 3, "Unsupported")]
    public void TryCalculate_InvalidOrUnsupportedInput_ReturnsFalseAndZeroCalories(
        string? gender,
        int age,
        int weightKg,
        int heightCm,
        int activityLevel,
        string? goal)
    {
        var result = CalorieCalculator.TryCalculate(
            gender,
            age,
            weightKg,
            heightCm,
            activityLevel,
            goal,
            out var dailyCalories);

        Assert.IsFalse(result);
        Assert.AreEqual(0m, dailyCalories);
    }
}
