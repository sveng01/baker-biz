using System;
using BakerBiz.Model;

namespace BakerBiz.Utilities
{
    public static class PieCalculator
    {
        public static int CalculateNumPies(IPieRecipe recipe)
        {
            try
            {
                var maxPies = recipe.Ingredients.Min(x => x.CalculateWholePies());
                return maxPies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}