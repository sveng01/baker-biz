using System;
using BakerBiz.Model;

namespace BakerBiz.Utilities
{
    public static class MenuItemCalculator
    {
        public static int CalculateNumMenuItems(IRecipe recipe)
        {
            try
            {
                var maxItems = recipe.Ingredients.Min(x => x.CalculateWholeMenuItems());
                return maxItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}