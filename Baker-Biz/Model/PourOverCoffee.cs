using System;

namespace BakerBiz.Model;

public class PourOverCoffee : IRecipe
{
        public IList<Ingredient> Ingredients { get; private set; }

        public string Name { get; private set; }

        public PourOverCoffee()
        {
            Name = "Pour Over Coffee";
            Ingredients = new List<Ingredient>(){
                
                new Ingredient(IngredientType.PourOverCoffee, 22.0/(5.0*453.0), Units.bags),
            };
        }
}