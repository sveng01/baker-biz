using BakerBiz.Model;
using BakerBiz.Utilities;
using BakerBiz.Workflows;

namespace BakerBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is intended to run on .NET Core
            RecipeDataAccess dataAccess = new RecipeDataAccess();

            do
            {
                WorkflowType workFlowType = ChooseWorkflow();

                switch (workFlowType)
                {
                    case WorkflowType.CalculateMenuItems:
                        StartMenuItemWorkflow(dataAccess);
                        break;
                    case WorkflowType.CalculateIngredients:
                        StartIngredientWorkflow(dataAccess);
                        break;
                    default:
                        Console.Write("Invalid selection. Follow directions next time.  Bye bye!");
                        throw new Exception("Invalid selection");
                }

                Console.WriteLine("\n\nEnter to calculate, 'q' to quit!");
            }
            while (!string.Equals(Console.ReadLine(), "Q", StringComparison.OrdinalIgnoreCase));

        }

        private static void StartIngredientWorkflow(RecipeDataAccess dataAccess)
        {
            IngredientsWorkflow workflow = new IngredientsWorkflow();
            IngredientsWorkflowInputProvider inputProvider = new IngredientsWorkflowInputProvider();
            IngredientsWorkflowResults result =  workflow.Execute(dataAccess, inputProvider);
            PrintIngredientList(result);
        }

        private static void PrintIngredientList(IngredientsWorkflowResults results)
        {
            foreach(Ingredient ingredient in results.Ingredients){
                Console.WriteLine($"You need {ingredient.Amount} {ingredient.Units.ToString()}(s) of {ingredient.Type}");
            }
        }

        private static void StartMenuItemWorkflow(RecipeDataAccess dataAccess)
        {
            MenuItemWorkflow workflow = new MenuItemWorkflow();
            MenuItemWorkflowConsoleProvider inputProvider = new MenuItemWorkflowConsoleProvider();
            MenuItemWorkflowResult result = workflow.Execute(dataAccess, inputProvider);

            Console.WriteLine("You can make:");
            Console.WriteLine(result?.TotalCount + " " + result?.MenuItem?.Name);

            PrintLeftovers(result?.MenuItem, result.TotalCount);
        }

        private static WorkflowType ChooseWorkflow()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Enter 1 to calculate how much you can make with what you have.");
            Console.WriteLine("Enter 2 to calculate how much you need to make what you want.");
            var selectionEntered = Console.ReadLine();
            int selection = 0;
            InputHelper.ParseInputStrings(selectionEntered, "WorkflowType", out selection);

            return (WorkflowType)selection;
        }

        private static void PrintLeftovers(IRecipe recipe, int pieCount)
        {
            if (recipe != null && recipe.Ingredients.Any())
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.CalculateLeftovers(pieCount)} {ingredient.Units}(s) {ingredient.Type} left over.");
                }
            }
        }



    }




}
