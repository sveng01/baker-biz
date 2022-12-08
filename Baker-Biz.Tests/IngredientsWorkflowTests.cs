using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Workflows;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests
{
    public class IngredientsWorkflowTests
    {
        [Fact]
        public void Execute_Test()
        {
            IngredientsWorkflow workflow = new IngredientsWorkflow();
            var result = workflow.Execute(new MockDataAccess(), new MockIngredientsInputProvider());

            Assert.Equal(2, result.Ingredients.Count);
            Assert.Equal(12, result.Ingredients[0].Amount);
            Assert.Equal(IngredientType.Apples, result.Ingredients[0].Type);
            Assert.Equal(Units.bags, result.Ingredients[0].Units);
            Assert.Equal(36, result.Ingredients[1].Amount);
            Assert.Equal(IngredientType.Sugar, result.Ingredients[1].Type);
            Assert.Equal(Units.tbsp, result.Ingredients[1].Units);
        }
    }
}
