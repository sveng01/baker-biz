using System;
using BakerBiz.Model;
using BakerBiz.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace BakerBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core

            IRecipe? menuItem;
            RecipeDataAccess dataAccess = new RecipeDataAccess();

            do
            {
                menuItem = ChooseMenuItem(dataAccess);

                if (menuItem == null) //ask again
                    continue;

                foreach (Ingredient ingredient in menuItem.Ingredients)
                {
                    bool inputAmountIsValid = false;
                    while (!inputAmountIsValid)
                    {
                        Console.WriteLine($"Enter the {ingredient.Units} of {ingredient.Type}");
                        var amountEntered = Console.ReadLine();
                        int amount;
                        inputAmountIsValid = ParseInputStrings(amountEntered, ingredient.Type, out amount);
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
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");

            } while (!string.Equals(Console.ReadLine(), "Q", StringComparison.OrdinalIgnoreCase));

        }

        private static IRecipe? ChooseMenuItem(RecipeDataAccess recipeDataAccess)
        {
            IRecipe? menuItem = null;
            Console.WriteLine("Enter:");

            RecipeBase[] recipeList = recipeDataAccess.LoadRecipes();

            for(int i = 1; i <= recipeList.Length; i++){
                Console.WriteLine($"{i} for {recipeList[i-1].Name}");
            }
            var recipeEntered = Console.ReadLine();
            int recipeNumber = 0;
            bool success = int.TryParse(recipeEntered, out recipeNumber);
            menuItem = recipeList[recipeNumber -1];
            return menuItem;
        }

        private static void PrintLeftovers(IRecipe recipe, int pieCount)
        {
            if (recipe != null && recipe.Ingredients.Any())
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.CalculateLeftovers(pieCount)} {ingredient.Units}(s) {ingredient.Type} left over.");
                }
            }
        }

        private static bool ParseInputStrings(string input, IngredientType ingredientType, out int result)
        {
            if (string.IsNullOrEmpty(input))
            {
                result = 0;
                return false;
            }

            bool success = int.TryParse(input, out result);

            if (!success)
            {
                Console.WriteLine($"I do not understand \"{input}\" {ingredientType}. What does that even mean?  Come on MAN!!!");
                Console.WriteLine("Let's try again please.");
            }

            return success;
        }
    }




}
