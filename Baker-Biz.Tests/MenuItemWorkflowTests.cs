using BakerBiz;
using BakerBiz.Model;
using BakerBiz.Workflows;
using BakerBiz.Utilities;

namespace Baker_Biz.Tests
{
    public class MenuItemWorkflowTests
    {
        [Fact]
        public void Execute_Test()
        {
            MenuItemWorkflow workflow = new MenuItemWorkflow();
            var result = workflow.Execute(new MockDataAccess(), new MockMenuItemInputProvider());

            Assert.Equal(2, result.TotalCount);
            Assert.Equal(12, result.MenuItem.Ingredients[0].Amount);
            Assert.Equal(12, result.MenuItem.Ingredients[1].Amount);
        }
    }
}
