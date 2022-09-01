using System;

namespace BakerBiz.Model
{
    public class ApplePieRecipe : IRecipe
    {
        public IList<Ingredient> Ingredients { get; private set; }

        public string Name { get; private set; }

        public ApplePieRecipe()
        {
            Name = "Apple Pie";
            Ingredients = new List<Ingredient>(){
                new Ingredient(IngredientType.Apples, 3, Units.number),
                new Ingredient(IngredientType.Sugar, 2, Units.lbs),
                new Ingredient(IngredientType.Flour, 1, Units.lbs),
                new Ingredient(IngredientType.Cinnamon, 1, Units.tsp, false),
                new Ingredient(IngredientType.Butter, 0.75d, Units.sticks),
            };
        }
    }
}
