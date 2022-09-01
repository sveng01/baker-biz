using System;

namespace BakerBiz.Model;

public class EspressoCoffee : IRecipe
{
        public IList<Ingredient> Ingredients { get; private set; }

        public string Name { get; private set; }

        public EspressoCoffee()
        {
            Name = "Espresso Coffee";
            Ingredients = new List<Ingredient>(){
                
                new Ingredient(IngredientType.Espresso, 8.0/(5.0*453.0), Units.bags),
            };
        }
}