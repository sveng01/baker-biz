using System;

namespace Interview_Refactor1
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to maximize the number of apple pies we can make.
            // it takes 3 apples, 2 lbs of sugar and 1 pound of flour to make 1 apple pie
            // this is intended to run on .NET Core

            ApplePieRecipe applePie = new ApplePieRecipe();
            do
            {
                foreach(Ingredient ingredient in applePie.Ingredients){
                    Console.WriteLine($"Enter the {ingredient.Units} of {ingredient.Name}");
                    var amountEntered = Console.ReadLine();
                    int amount;
                    if (!ParseInputStrings(amountEntered, ingredient.Name, out amount)){
                    continue;
                    }
                    else{
                        ingredient.Amount = amount;
                    }
                }
                
                int pieCount = PieCalculator.CalculateNumPies(applePie);
                PieCalculator.PrintLeftovers(applePie, pieCount);
                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");

            } while (!string.Equals(Console.ReadLine(), "Q", StringComparison.OrdinalIgnoreCase));

        }

        private static bool ParseInputStrings(string input, string ingredientName, out int result)
        {
            if(string.IsNullOrEmpty(input))
            {
                result = 0;
                return false;
            }

            bool success = int.TryParse(input, out result);

            if (!success)
            {
                Console.WriteLine($"I do not understand \"{input}\" {ingredientName}. What does that even mean?  Come on MAN!!!");
                Console.WriteLine("Let's try again please, from the beginning.  Hit <enter>");
            }

            return success;
        }
    }



    
}
