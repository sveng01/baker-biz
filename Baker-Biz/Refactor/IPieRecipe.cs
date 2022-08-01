using System;

namespace Interview_Refactor1
{
    public interface IPieRecipe
    {
        IList<Ingredient> Ingredients { get; }
        string Name { get; }

    }
}