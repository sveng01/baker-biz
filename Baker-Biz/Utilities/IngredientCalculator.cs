using System;
using BakerBiz.Model;

namespace BakerBiz.Utilities
{
    public static class IngredientCalculator
    {
        public static IList<Ingredient> CalculateIngredientsNeeded(IRecipe recipe, int quantity)
        {
            IList<Ingredient> ingredients = new List<Ingredient>();

            foreach(Ingredient ingred in recipe.Ingredients)
            {
                ingred.CalculateAmount(quantity);
                ingredients.Add(ingred);
            }

            return ingredients;
        }
    }
}