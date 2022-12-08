using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BakerBiz.Model
{
    public class IngredientsWorkflowResults
    {
        public IList<Ingredient> Ingredients {get; private set; }

        public IngredientsWorkflowResults(IList<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}