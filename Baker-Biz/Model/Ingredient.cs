using System;
using System.Text.Json.Serialization;

namespace BakerBiz.Model
{
    public class Ingredient
    {
        public IngredientType Type { get; set; }
        public double AmountPerItem { get; set; }
        [JsonIgnore]
        public double Amount { get; set; }
        public Units Units { get; set; }
        public bool Required { get; set; }

        [JsonConstructor]
        public Ingredient()
        {

        }

        public Ingredient(IngredientType type, double perItemAmount, Units units, bool required = true)
        {
            Type = type;
            AmountPerItem = perItemAmount;
            Units = units;
            Required = required;
        }

        public int CalculateWholeMenuItems()
        {
            if (Amount == 0 && !Required)
            {
                //return Max value so that we know this is not part of the calculation for max number of pies
                return int.MaxValue;
            }

            int numberOfItems = 0;
            if (AmountPerItem > 0)
            {
                double items = (Amount / AmountPerItem);
                numberOfItems = (int)Math.Floor(items);
            }
            return numberOfItems;
        }

        public double CalculateLeftovers(int numberOfItems)
        {
            double leftOvers = Amount - (numberOfItems * AmountPerItem);

            if (leftOvers < 0)
                leftOvers = 0;

            return Math.Round(leftOvers, 2);
        }

        public double CalculateAmount(int quantity)
        {
            Amount = quantity * AmountPerItem;
            return Amount;
        }
    }
}