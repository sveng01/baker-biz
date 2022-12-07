using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BakerBiz.Model
{
    public class RecipeBase : IRecipe
    {
        [JsonPropertyOrder(0)]
        public string Name { get; set; }

        [JsonPropertyOrder(1)]
        public IList<Ingredient> Ingredients { get; set; }

        public RecipeBase(string name, IEnumerable<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = new List<Ingredient>(ingredients.ToArray());
        }
    }
}
