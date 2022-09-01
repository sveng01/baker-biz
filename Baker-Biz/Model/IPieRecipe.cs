using System;

namespace BakerBiz.Model
{
    public interface IRecipe
    {
        IList<Ingredient> Ingredients { get; }
        string Name { get; }

    }
}