using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public class MenuItemWorkflow
    {
        public void Execute(RecipeDataAccess dataAccess)
        {
            IRecipe? menuItem = ChooseMenuItem(dataAccess);

            if (menuItem == null) //ask again
                return;

            foreach (Ingredient ingredient in menuItem.Ingredients)
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
                        ingredient.Amount = amount;
                    }
                }
            }

            int itemCount = MenuItemCalculator.CalculateNumMenuItems(menuItem);

            Console.WriteLine("You can make:");
            Console.WriteLine(itemCount + " " + menuItem.Name);

            PrintLeftovers(menuItem, itemCount);
        }

        private IRecipe? ChooseMenuItem(RecipeDataAccess recipeDataAccess)
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

        private void PrintLeftovers(IRecipe recipe, int pieCount)
        {
            if (recipe != null && recipe.Ingredients.Any())
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.CalculateLeftovers(pieCount)} {ingredient.Units}(s) {ingredient.Type} left over.");
                }
            }
        }

    }
}

