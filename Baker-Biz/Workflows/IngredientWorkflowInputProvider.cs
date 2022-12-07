using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public interface IIngredientWorkflowInputProvider
    {
        int GetRecipeQuantities( RecipeBase menuItem);
    }

    public class IngredientWorkflowInputProvider : IIngredientWorkflowInputProvider
    {
        public int GetRecipeQuantities(RecipeBase menuItem)
        {
            Console.WriteLine($"Enter the quantity for {menuItem.Name}");
            var quantityEntered = Console.ReadLine();
            int quantity = 0;
            bool success = int.TryParse(quantityEntered, out quantity);
            return quantity;
        }
    }
}