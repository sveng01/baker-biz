using System;
using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Utilities;

namespace BakerBiz.Workflows
{
    public class IngredientsWorkflow
    {
        public void Execute(RecipeDataAccess dataAccess)
        {
            //1.) loop through each recipe and ask for the number of menu items they want.
            var recipesQuantities = GetMenuItemQuantities(dataAccess);

            //2.) for each ingredient in each recipe, get the amount
            IEnumerable<Ingredient> ingredients = CalculateRecipeIngredients(recipesQuantities);

            //3.) print the total ingredients, over all recipes.
            PrintIngredientsShoppingList(ingredients);

            //4

        }

        private void PrintIngredientsShoppingList(IEnumerable<Ingredient> ingredients)
        {

            IngredientType[] ingredientTypes = Enum.GetValues<IngredientType>();
            foreach(IngredientType name in ingredientTypes)
            {
                var units = ingredients.FirstOrDefault(x => x.Type == name)?.Units;
                double sum = ingredients.Where(x => x.Type == name).Sum(y => y.Amount);
                sum = Math.Ceiling(sum);
                Console.WriteLine($"You need {sum} {units.ToString()}(s) of {name}");
            }

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

        private IList<Tuple<IRecipe, int>> GetMenuItemQuantities(RecipeDataAccess dataAccess)
        {
            RecipeBase[] recipeList = dataAccess.LoadRecipes();
            IList<Tuple<IRecipe, int>> recipeQuantities = new List<Tuple<IRecipe, int>>();

            for (int i = 1; i <= recipeList.Length; i++)
            {
                Console.WriteLine($"Enter the quantity for {recipeList[i - 1].Name}");
                var quantityEntered = Console.ReadLine();
                int quantity = 0;
                bool success = int.TryParse(quantityEntered, out quantity);
                var menuItem = recipeList[i - 1];
                recipeQuantities.Add(new Tuple<IRecipe, int>(menuItem, quantity));
            }

            return recipeQuantities;

        }
    }
}