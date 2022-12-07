using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Workflows;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests
{
    public static class MockRecipes
    {
        public static RecipeBase GetAppleCiderRecipe()
        {
            RecipeBase recipeBase = new RecipeBase("Apple Cider", new Ingredient[] 
            { 
                new Ingredient(IngredientType.Apples, 2, Units.bags) ,
                new Ingredient(IngredientType.Sugar, 6, Units.tbsp)
                });

            return recipeBase;
        }
    }

    public class MockDataAccess : IRecipeDataAccess
    {
        public RecipeBase[] LoadRecipes()
        {
            RecipeBase recipeBase = MockRecipes.GetAppleCiderRecipe();

            return new RecipeBase[] { recipeBase };
        }

        public void SaveRecipes(IList<IRecipe> recipes)
        {
            throw new NotImplementedException();
        }
    }

    public class MockMenuItemInputProvider : IMenuItemWorkflowInputProvider
    {
        public IRecipe? ChooseMenuItem(IRecipeDataAccess recipeDataAccess)
        {
            return MockRecipes.GetAppleCiderRecipe();
        }

        public int GetIngredientAmount(Ingredient ingredient)
        {
            return 12;
        }
    }

    public class MockIngredientsInputProvider : IIngredientWorkflowInputProvider
    {
        public int GetRecipeQuantities(RecipeBase menuItem)
        {
            return 6;
        }
    }
}