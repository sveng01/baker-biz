using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public interface IIngredientsWorkflowInputProvider
    {
        IList<Tuple<IRecipe, int>> GetRecipeQuantities(IRecipeDataAccess dataAccess);
    }

    public class IngredientsWorkflowInputProvider : IIngredientsWorkflowInputProvider
    {
        public IList<Tuple<IRecipe, int>> GetRecipeQuantities(IRecipeDataAccess dataAccess)
        {
            RecipeBase[] recipeList = dataAccess.LoadRecipes();
            IList<Tuple<IRecipe, int>> recipeQuantities = new List<Tuple<IRecipe, int>>();

            for (int i = 1; i <= recipeList.Length; i++)
            {
                Console.WriteLine($"Enter the quantity for {recipeList[i - 1].Name}");
                var quantityEntered = Console.ReadLine();
                int quantity = 0;
                bool success = int.TryParse(quantityEntered, out quantity);
                var menuItem = recipeList[i - 1];
                recipeQuantities.Add(new Tuple<IRecipe, int>(menuItem, quantity));
            }

            return recipeQuantities;
        }
    }
}