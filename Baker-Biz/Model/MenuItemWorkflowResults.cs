using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BakerBiz.Model
{
    public class MenuItemWorkflowResult
    {
        public IRecipe? MenuItem { get; private set; }

        public int TotalCount { get; private set; }

        public MenuItemWorkflowResult(IRecipe menuItem, int count){
            MenuItem = menuItem;
            TotalCount = count;
        }
    }
}