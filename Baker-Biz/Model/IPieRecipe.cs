using System;

namespace BakerBiz.Model
{
    public interface IPieRecipe
    {
        IList<Ingredient> Ingredients { get; }
        string Name { get; }

    }
}