using SmartMeal.Models;

namespace UnitTests;

[TestClass]
public sealed class DishImagePathsTests
{
    [TestMethod]
    public void ForCategory_ReturnsSeededLocalImagePath_WhenCategoryIsKnown()
    {
        Assert.AreEqual("/images/dishes/breakfast.svg", DishImagePaths.ForCategory(1));
        Assert.AreEqual("/images/dishes/lunch.svg", DishImagePaths.ForCategory(2));
        Assert.AreEqual("/images/dishes/dinner.svg", DishImagePaths.ForCategory(3));
        Assert.AreEqual("/images/dishes/snack.svg", DishImagePaths.ForCategory(4));
    }

    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void WithFallback_NullOrEmptyImagePath_ReturnsDefaultImage(string? imageUrl)
    {
        Assert.AreEqual("/images/dishes/default.svg", DishImagePaths.WithFallback(imageUrl));
    }

    [TestMethod]
    public void WithFallback_DefaultImagePath_RemainsAvailableForUserCreatedRecipes()
    {
        Assert.AreEqual("/images/dishes/default.svg", DishImagePaths.WithFallback("/images/dishes/default.svg"));
    }

    [TestMethod]
    public void WithFallback_CustomImagePath_ReturnsOriginalPath()
    {
        const string seededPath = "/images/dishes/seeded/oatmeal-with-apple.png";

        Assert.AreEqual(seededPath, DishImagePaths.WithFallback(seededPath));
    }
}
