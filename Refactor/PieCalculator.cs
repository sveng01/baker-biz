using System;

namespace Interview_Refactor1
{
    public static class PieCalculator
    {
        public static int CalculateNumPies(IPieRecipe recipe)
        {
            try
            {
                var maxPies = recipe.Ingredients.Min(x => x.CalculateWholePies());
                Console.WriteLine("You can make:");
                Console.WriteLine(maxPies + " "  + recipe.Name);

                return maxPies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static void PrintLeftovers(IPieRecipe recipe, int pieCount){

            if(recipe != null && recipe.Ingredients.Any()){
                foreach(Ingredient ingredient in recipe.Ingredients){
                    Console.WriteLine($"{ingredient.CalculateLeftovers(pieCount)} {ingredient.Units}(s) {ingredient.Name} left over.");
                }
            }

        }
    }
}