using BakerBiz;
using BakerBiz.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Baker_Biz.Tests;

public class RecipeTests
{
    [Fact]
    public void RecipeSerializationTests(){
        ApplePieRecipe recipe = new ApplePieRecipe();

        string jsonString = JsonSerializer.Serialize(recipe);

            Console.WriteLine(jsonString);

    }
}