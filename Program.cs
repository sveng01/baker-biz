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

            int numApples = 0;
            int sugarLbs = 0;
            int flourLbs = 0;
            string? apples = "";
            string? sugar = "";
            string? flour = "";
            do
            {
                Console.WriteLine("How many apples do you have?");
                apples = Console.ReadLine();
                if (!ParseInputStrings(apples, "apples", out numApples))
                    continue;

                Console.WriteLine("How much sugar do you have?");
                sugar = Console.ReadLine();
                if (!ParseInputStrings(sugar, "sugar", out sugarLbs))
                    continue;

                Console.WriteLine("How many pounds of flour do you have?");
                flour = Console.ReadLine();
                if (!ParseInputStrings(flour, "flour", out flourLbs))
                    continue;

                Console.WriteLine("You can make:");

                var result = ApplePieCalculator.CalculateNumPies(numApples, sugarLbs, flourLbs);

                Console.WriteLine(result);
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



    public static class ApplePieCalculator
    {
        const int applesPerPie = 3;
        const int sugaLbsPerPie = 2;
        const int flourLbsPerPie = 1;
        public static PieRecipeCalculationResults CalculateNumPies(int numApples, int sugarLbs, int flourLbs)
        {
            try
            {
                var numPiesbyApple = numApples / applesPerPie;
                var numPiesbySugar = sugarLbs / sugaLbsPerPie;
                var numPiesbyFlour = flourLbs / flourLbsPerPie;
                var maxPies = Math.Min(Math.Min(numPiesbyApple, numPiesbySugar), numPiesbyFlour);

                Console.WriteLine(maxPies + " apple pies!");

                var leftOverApples = numApples - (maxPies * applesPerPie);
                var leftOverSugarLbs = sugarLbs - (maxPies * sugaLbsPerPie);
                var leftOverFlourLbs = flourLbs - (maxPies * flourLbsPerPie);

                PieRecipeCalculationResults results = new PieRecipeCalculationResults()
                {
                    NumApples = numApples,
                    NumPies = maxPies,
                    LeftOverApples = leftOverApples,
                    LeftOverFlourLbs = leftOverFlourLbs,
                    LeftOverSugarLbs = leftOverSugarLbs
                };

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
