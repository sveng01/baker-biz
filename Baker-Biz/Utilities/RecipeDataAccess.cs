using System;
using BakerBiz.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BakerBiz.Utilities
{
    public interface IRecipeDataAccess
    {
        RecipeBase[] LoadRecipes();
        void SaveRecipes(IList<IRecipe> recipes);
    }

    public class RecipeDataAccess : IRecipeDataAccess
    {

        private const string fileName = "Recipes.json";
        private JsonSerializerOptions serializationOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() }, WriteIndented = true };

        public RecipeDataAccess()
        {
        }

        public void SaveRecipes(IList<IRecipe> recipes)
        {
            string jsonString = JsonSerializer.Serialize(recipes, serializationOptions);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(jsonString);
            }
        }

        public RecipeBase[] LoadRecipes()
        {

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string json = reader.ReadToEnd();
                    var list = JsonSerializer.Deserialize<List<RecipeBase>>(json, serializationOptions);
                    return list.ToArray();
                }
            }
            else
            {
                throw new Exception("Could not find " + fileName);
            }
        }
    }
}