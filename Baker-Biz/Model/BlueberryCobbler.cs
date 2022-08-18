using System;

namespace BakerBiz.Model;

public class BlueberryCobbler : IPieRecipe
{
        public IList<Ingredient> Ingredients { get; private set; }

        public string Name { get; private set; }

        public BlueberryCobbler()
        {
            Name = "Blueberry Cobbler";
            Ingredients = new List<Ingredient>(){
                new Ingredient(IngredientType.Blueberries, 4, Units.cup),
                new Ingredient(IngredientType.LemonZest, 1, Units.number),
                new Ingredient(IngredientType.Butter, 5, Units.tbsp),
                new Ingredient(IngredientType.Flour, 1, Units.cup),
                new Ingredient(IngredientType.Sugar, 1, Units.cup),
                new Ingredient(IngredientType.Milk, 1, Units.cup),
                new Ingredient(IngredientType.Cinnamon, 1, Units.tsp),
            };
        }
}