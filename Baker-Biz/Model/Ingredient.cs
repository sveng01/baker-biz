using System;

namespace BakerBiz.Model
{
    public class Ingredient
    {
        public IngredientType Type { get; private set; }
        public double AmountPerPie { get; private set; }
        public int Amount { get; set; }
        public Units Units { get; private set; }
        public bool Required { get; private set; }

        public Ingredient(IngredientType type, double perPieAmount, Units units, bool required = true)
        {
            Type = type;
            AmountPerPie = perPieAmount;
            Units = units;
            Required = required;
        }

        public int CalculateWholePies()
        {
            if (Amount == 0 && !Required)
            {
                //return Max value so that we know this is not part of the calculation for max number of pies
                return int.MaxValue;
            }

            int numberOfPies = 0;
            if (AmountPerPie > 0)
            {
                double pies = (Amount / AmountPerPie);
                numberOfPies = (int)Math.Floor(pies);
            }
            return numberOfPies;
        }

        public double CalculateLeftovers(int numberOfPies)
        {
            double leftOvers = Amount - (numberOfPies * AmountPerPie);

            if (leftOvers < 0)
                leftOvers = 0;

            return leftOvers;
        }
    }
}