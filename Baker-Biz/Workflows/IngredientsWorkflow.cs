using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public class IngredientsWorkflow
    {
        public IEnumerable<Ingredient> Execute(IRecipeDataAccess dataAccess, IIngredientWorkflowInputProvider inputProvider)
        {
            //1.) loop through each recipe and ask for the number of menu items they want.
            var recipesQuantities = GetMenuItemQuantities(dataAccess, inputProvider);

            //2.) for each ingredient in each recipe, get the amount
            IEnumerable<Ingredient> ingredients = CalculateRecipeIngredients(recipesQuantities);

            //3.) print the total ingredients, over all recipes.
            return ingredients;
        }


        private IEnumerable<Ingredient> CalculateRecipeIngredients(IList<Tuple<IRecipe, int>> recipesQuantities)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in recipesQuantities)
            {
                IRecipe recipe = item.Item1;
                int quantity = item.Item2;

                ingredients.AddRange(IngredientCalculator.CalculateIngredientsNeeded(recipe, quantity));
            }

            return ingredients;
        }

        private IList<Tuple<IRecipe, int>> GetMenuItemQuantities(IRecipeDataAccess dataAccess, IIngredientWorkflowInputProvider inputProvider)
        {
            RecipeBase[] recipeList = dataAccess.LoadRecipes();
            IList<Tuple<IRecipe, int>> recipeQuantities = new List<Tuple<IRecipe, int>>();

            for (int i = 1; i <= recipeList.Length; i++)
            {
                var menuItem = recipeList[i - 1];
                int quantity = inputProvider.GetRecipeQuantities(menuItem);
                recipeQuantities.Add(new Tuple<IRecipe, int>(menuItem, quantity));
            }

            return recipeQuantities;

        }
    }
}