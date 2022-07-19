using System;

namespace Interview_Refactor1
{
    public class ApplePieRecipe : IPieRecipe
    {
        public IList<Ingredient> Ingredients { get; private set; }

        public string Name { get; private set; }

        public ApplePieRecipe()
        {
            Name = "Apple Pie";
            Ingredients = new List<Ingredient>(){
                new Ingredient("apples", 3, "#"),
                new Ingredient("sugar", 2, "lbs"),
                new Ingredient("flour", 1, "lbs"),
                new Ingredient("cinnamon", 1, "tsp", false),
            };
        }


    }
}
