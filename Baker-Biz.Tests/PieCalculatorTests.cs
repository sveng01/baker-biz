using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests;

public class PieCalculatorTests{

    [Fact]
    public void CalculateNumPies_TestWithCinnamon(){
        IRecipe recipe = new ApplePieRecipe();

        recipe.Ingredients.Single(x => x.Type == IngredientType.Apples).Amount = 6;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Sugar).Amount = 4; 
        recipe.Ingredients.Single(x => x.Type == IngredientType.Flour).Amount = 2;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Cinnamon).Amount = 2;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Butter).Amount = 2;
        int numPies = MenuItemCalculator.CalculateNumMenuItems(recipe);
        Assert.True(numPies == 2, "Failed to calculate number of pies");
    }

    [Fact]
    public void CalculateNumPies_TestWithoutCinnamon(){
        IRecipe recipe = new ApplePieRecipe();

        recipe.Ingredients.Single(x => x.Type == IngredientType.Apples).Amount = 6;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Sugar).Amount = 4; 
        recipe.Ingredients.Single(x => x.Type == IngredientType.Flour).Amount = 2;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Cinnamon).Amount = 0;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Butter).Amount = 2;
        int numPies = MenuItemCalculator.CalculateNumMenuItems(recipe);
        Assert.True(numPies == 2, "Failed to calculate number of pies");
    }
}