using SmartMeal.Models.ViewModels;

namespace UnitTests;

[TestClass]
public sealed class WeeklyReportViewModelTests
{
    [TestMethod]
    public void MaxDailyCaloriesForChart_WhenNoCaloriesExist_ReturnsOne()
    {
        var model = new WeeklyReportViewModel();

        Assert.AreEqual(1m, model.MaxDailyCaloriesForChart);
    }

    [TestMethod]
    public void MaxDailyCaloriesForChart_UsesGreaterOfDailyTargetAndDayCalories()
    {
        var model = new WeeklyReportViewModel
        {
            DailyCalorieTarget = 1800m,
            Days =
            [
                new WeeklyReportDayViewModel { Calories = 1200m },
                new WeeklyReportDayViewModel { Calories = 2100m }
            ]
        };

        Assert.AreEqual(2100m, model.MaxDailyCaloriesForChart);
    }

    [TestMethod]
    public void WeeklyMacroPercentages_ReturnExpectedValues_ForNormalTotals()
    {
        var model = new WeeklyReportViewModel
        {
            WeeklyTotalProteins = 100m,
            WeeklyTotalFats = 50m,
            WeeklyTotalCarbs = 350m
        };

        Assert.AreEqual(500m, model.WeeklyMacroTotal);
        Assert.IsTrue(model.HasWeeklyMacros);
        Assert.AreEqual(20, model.WeeklyProteinsPercent);
        Assert.AreEqual(10, model.WeeklyFatsPercent);
        Assert.AreEqual(70, model.WeeklyCarbsPercent);
    }

    [TestMethod]
    public void WeeklyMacroPercentages_WithZeroTotals_ReturnZeroAndNoMacros()
    {
        var model = new WeeklyReportViewModel();

        Assert.AreEqual(0m, model.WeeklyMacroTotal);
        Assert.IsFalse(model.HasWeeklyMacros);
        Assert.AreEqual(0, model.WeeklyProteinsPercent);
        Assert.AreEqual(0, model.WeeklyFatsPercent);
        Assert.AreEqual(0, model.WeeklyCarbsPercent);
    }

    [TestMethod]
    public void StatusCounters_CountMatchingDayStatuses()
    {
        var model = new WeeklyReportViewModel
        {
            Days =
            [
                new WeeklyReportDayViewModel { Status = "\u041d\u0435\u0434\u043e\u0431\u043e\u0440" },
                new WeeklyReportDayViewModel { Status = "\u0412 \u043d\u043e\u0440\u043c\u0435" },
                new WeeklyReportDayViewModel { Status = "\u0412 \u043d\u043e\u0440\u043c\u0435" },
                new WeeklyReportDayViewModel { Status = "\u041f\u0440\u0435\u0432\u044b\u0448\u0435\u043d\u0438\u0435" },
                new WeeklyReportDayViewModel { Status = "Other" }
            ]
        };

        Assert.AreEqual(1, model.DaysBelowTargetCount);
        Assert.AreEqual(2, model.DaysInTargetRangeCount);
        Assert.AreEqual(1, model.DaysAboveTargetCount);
    }

    [TestMethod]
    public void GetCalorieChartPercent_UsesChartMaximumAndCapsAtOneHundred()
    {
        var model = new WeeklyReportViewModel
        {
            DailyCalorieTarget = 2000m,
            Days = [new WeeklyReportDayViewModel { Calories = 2000m }]
        };

        Assert.AreEqual(50, model.GetCalorieChartPercent(1000m));
        Assert.AreEqual(100, model.GetCalorieChartPercent(2500m));
    }
}
