using System;

namespace BakerBiz.Model
{
    public class Ingredient
    {
        public IngredientType Type { get; private set; }
        public double AmountPerItem { get; private set; }
        public int Amount { get; set; }
        public Units Units { get; private set; }
        public bool Required { get; private set; }

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
    }
}