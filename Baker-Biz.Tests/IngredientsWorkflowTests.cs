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

            Assert.Equal(2, result.Count());
            Assert.Equal(12, result.First().Amount);
             Assert.Equal(36, result.ElementAt(1).Amount);
        }
    }
}
