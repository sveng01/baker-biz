using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests;

public class PieCalculatorTests{

    [Fact]
    public void CalculateNumPies_TestWithCinnamon(){
        IRecipe recipe = new RecipeBase("Apple Pie",
            new List<Ingredient>(){
                new Ingredient(IngredientType.Apples, 3, Units.number),
                new Ingredient(IngredientType.Sugar, 2, Units.lbs),
                new Ingredient(IngredientType.Flour, 1, Units.lbs),
                new Ingredient(IngredientType.Cinnamon, 1, Units.tsp, false),
                new Ingredient(IngredientType.Butter, 0.75d, Units.sticks),
            }
        );

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
        IRecipe recipe = new RecipeBase("Apple Pie",
             new List<Ingredient> (){
                new Ingredient(IngredientType.Apples, 3, Units.number),
                new Ingredient(IngredientType.Sugar, 2, Units.lbs),
                new Ingredient(IngredientType.Flour, 1, Units.lbs),
                new Ingredient(IngredientType.Cinnamon, 1, Units.tsp, false),
                new Ingredient(IngredientType.Butter, 0.75d, Units.sticks),
            }
        );

        recipe.Ingredients.Single(x => x.Type == IngredientType.Apples).Amount = 6;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Sugar).Amount = 4; 
        recipe.Ingredients.Single(x => x.Type == IngredientType.Flour).Amount = 2;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Cinnamon).Amount = 0;
        recipe.Ingredients.Single(x => x.Type == IngredientType.Butter).Amount = 2;
        int numPies = MenuItemCalculator.CalculateNumMenuItems(recipe);
        Assert.True(numPies == 2, "Failed to calculate number of pies");
    }
}