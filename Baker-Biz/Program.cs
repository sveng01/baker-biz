using System;
using BakerBiz.Model;
using BakerBiz.Utilities;

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

            do
            {
                menuItem = ChooseMenuItem();

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

        private static IRecipe? ChooseMenuItem()
        {
            IRecipe? menuItem;
            Console.WriteLine("Enter:"); 
            Console.WriteLine("1 for apple pie");
            Console.WriteLine("2 for blueberry cobbler");
            Console.WriteLine("3 for cups of Espresso");
            Console.WriteLine("4 for cups of Pour Over Coffee");
            var recipeEntered = Console.ReadLine();
            int recipeNumber = 0;
            bool success = int.TryParse(recipeEntered, out recipeNumber);

            switch (recipeNumber)
            {
                case 1:
                    menuItem = new ApplePieRecipe();
                    break;
                case 2:
                    menuItem = new BlueberryCobbler();
                    break;
                case 3:
                    menuItem = new EspressoCoffee();
                    break;                
                case 4:
                    menuItem = new PourOverCoffee();
                    break;
                default:
                    menuItem = null;
                    break;
            }

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
