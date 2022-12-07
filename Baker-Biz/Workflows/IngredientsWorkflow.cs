using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public class IngredientsWorkflow
    {
        public IngredientsWorkflowResults Execute(IRecipeDataAccess dataAccess, IIngredientsWorkflowInputProvider inputProvider)
        {
            //1.) loop through each recipe and ask for the number of menu items they want.
            var recipesQuantities = inputProvider.GetRecipeQuantities(dataAccess);

            //2.) for each ingredient in each recipe, get the amount
            IEnumerable<Ingredient> ingredients = CalculateRecipeIngredients(recipesQuantities);

            //3.) print the total ingredients, over all recipes.
            var shoppingList = CalculateIngredientsShoppingList(ingredients);

            return new IngredientsWorkflowResults(shoppingList);

        }

        private IList<Ingredient> CalculateIngredientsShoppingList(IEnumerable<Ingredient> ingredients)
        {

            IngredientType[] ingredientTypes = Enum.GetValues<IngredientType>();
            IList<Ingredient> ingredientsShoppingList = new List<Ingredient>();
            foreach (IngredientType name in ingredientTypes)
            {
                double sum = ingredients.Where(x => x.Type == name).Sum(y => y.Amount);
                sum = Math.Ceiling(sum);
                if (sum > 0)
                {
                    Units? units = ingredients.FirstOrDefault(x => x.Type == name)?.Units;
                    ingredientsShoppingList.Add(new Ingredient()
                    {
                        Amount = sum,
                        Type = name,
                        Units = units.HasValue ? units.Value : Units.number
                    });
                }
            }
            return ingredientsShoppingList;

        }

        private IEnumerable<Ingredient> CalculateRecipeIngredients(IList<Tuple<IRecipe, int>> recipesQuantities)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in recipesQuantities)
            {
                IRecipe recipe = item.Item1;
                int quantity = item.Item2;

                ingredients.AddRange(IngredientCalculator.CalculateIngredientsNeeded(recipe, quantity));
            }

            return ingredients;
        }
    }
}