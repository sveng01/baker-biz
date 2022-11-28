using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Workflows;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests
{
    public class MenuItemWorkflowTests
    {
        [Fact]
        public void Execute_Test()
        {
            MenuItemWorkflow workflow = new MenuItemWorkflow();
            MenuItemWorkflowResult result = workflow.Execute(new MockDataAccess(), new MockInputProvider());

            Assert.Equal(3, result.TotalCount);
            Assert.Equal(6, result.MenuItem.Ingredients[0].Amount);
        }
    }

    public static class TestRecipes
    {
        public static RecipeBase GetAppleCiderRecipe()
        {
            RecipeBase recipeBase = new RecipeBase()
            {
                Name = "Apple Cider"
            };
            recipeBase.Ingredients = new List<Ingredient>()
            {
                new Ingredient(IngredientType.Apples, 2, Units.bags)
            };
            return recipeBase;
        }
    }

    public class MockDataAccess : IRecipeDataAccess
    {
        public RecipeBase[] LoadRecipes()
        {
            RecipeBase recipeBase = TestRecipes.GetAppleCiderRecipe();

            return new RecipeBase[] { recipeBase };
        }

        public void SaveRecipes(IList<IRecipe> recipes)
        {
            throw new NotImplementedException();
        }
    }

    public class MockInputProvider : IMenuItemWorkflowInputProvider
    {
        public IRecipe? ChooseMenuItem(IRecipeDataAccess recipeDataAccess)
        {
            return TestRecipes.GetAppleCiderRecipe();
        }

        public int GetIngredientAmount(Ingredient ingredient)
        {
            return 6;
        }
    }

}
