using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public interface IMenuItemWorkflowInputProvider
    {
        IRecipe? ChooseMenuItem(RecipeDataAccess recipeDataAccess);
        int GetIngredientAmount(Ingredient ingredient);
    }
    public class MenuItemWorkflowConsoleProvider : IMenuItemWorkflowInputProvider
    {
        public IRecipe? ChooseMenuItem(RecipeDataAccess recipeDataAccess)
        {
            IRecipe? menuItem = null;
            Console.WriteLine("Enter:");

            RecipeBase[] recipeList = recipeDataAccess.LoadRecipes();

            for (int i = 1; i <= recipeList.Length; i++)
            {
                Console.WriteLine($"{i} for {recipeList[i - 1].Name}");
            }
            var recipeEntered = Console.ReadLine();
            int recipeNumber = 0;
            bool success = int.TryParse(recipeEntered, out recipeNumber);
            menuItem = recipeList[recipeNumber - 1];
            return menuItem;
        }

        public int GetIngredientAmount(Ingredient ingredient)
        {
            bool inputAmountIsValid = false;
            while (!inputAmountIsValid)
            {
                Console.WriteLine($"Enter the {ingredient.Units} of {ingredient.Type}");
                var amountEntered = Console.ReadLine();
                int amount;
                inputAmountIsValid = InputHelper.ParseInputStrings(amountEntered, ingredient.Type.ToString(), out amount);
                if (inputAmountIsValid)
                {
                    return amount;
                }
            }
            return 0;
        }
    }
}