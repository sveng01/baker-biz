using BakerBiz;
using BakerBiz.Model;

namespace Baker_Biz.Tests;

public class IngredientTests
{
    [Fact]
    public void CalculateWholeMenuItems_TestRequired()
    {
        Ingredient ingredient = new Ingredient(IngredientType.Apples, 2, Units.number);
        ingredient.Amount = 7;

        Assert.True(ingredient.CalculateWholeMenuItems() == 3, "Failed to calculate 3 pies.");

    }

    [Fact]
    public void CalculateWholeMenuItems_TestDoubleRequired()
    {
        Ingredient ingredient = new Ingredient(IngredientType.Butter, 0.75d, Units.sticks);
        ingredient.Amount = 2;
        int pies = ingredient.CalculateWholeMenuItems();

        Assert.True( pies == 2, $"Failed to calculate 2 pies. Calculated {pies}");

    }

    [Fact]
    public void CalculateWholeMenuItems_TestNotRequired()
    {
        Ingredient ingredient = new Ingredient(IngredientType.Apples, 2, Units.number, false);
        ingredient.Amount = 0;

        Assert.True(ingredient.CalculateWholeMenuItems() == int.MaxValue, "Failed to handle optional ingredient.");

    }

    [Fact]
    public void CalculateLeftovers_Test(){
        Ingredient ingredient = new Ingredient(IngredientType.Flour, 3, Units.lbs, true);
        ingredient.Amount = 11;

        Assert.True(ingredient.CalculateLeftovers(3) == 2, "Failed to calculate 2 lbs leftover");
    }

    [Fact]
    public void CalculateLeftovers_TestDouble(){
        Ingredient ingredient = new Ingredient(IngredientType.Butter, 0.75, Units.sticks, true);
        ingredient.Amount = 11;

        Assert.True(ingredient.CalculateLeftovers(11) == 2.75, "Failed to calculate 2.75 sticks leftover");
    }

    [Fact]
    public void CalculateAmount(){
        Ingredient ingredient = new Ingredient(IngredientType.Butter, 0.75, Units.sticks, true);

        double amount = ingredient.CalculateAmount(77);
        Assert.Equal(amount, 57.75);
        Assert.Equal(amount, ingredient.Amount);
        
    }
}