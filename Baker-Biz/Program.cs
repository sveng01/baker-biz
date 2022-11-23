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
            workflow.Execute(dataAccess);
        }

        private static void StartMenuItemWorkflow(RecipeDataAccess dataAccess)
        {
            MenuItemWorkflow workflow = new MenuItemWorkflow();
            workflow.Execute(dataAccess);
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




    }




}
