using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public class MenuItemWorkflow
    {
        public MenuItemWorkflowResult? Execute(IRecipeDataAccess dataAccess, IMenuItemWorkflowInputProvider inputProvider)
        {
            IRecipe? menuItem = inputProvider.ChooseMenuItem(dataAccess);

            if (menuItem == null) //ask again
                return null;

            foreach (Ingredient ingredient in menuItem.Ingredients)
            {
                ingredient.Amount = inputProvider.GetIngredientAmount(ingredient);
            }

            int itemCount = MenuItemCalculator.CalculateNumMenuItems(menuItem);

            return new MenuItemWorkflowResult(menuItem, itemCount);
        }


    }
}

