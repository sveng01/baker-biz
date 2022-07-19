using System;

namespace Interview_Refactor1
{
    public class Ingredient
    {
        public string Name {get; private set;}
        public int AmountPerPie {get; private set;}
        public int Amount {get; set;}
        public string Units {get; private set;}

        public bool Required {get; private set;}

        public Ingredient(string name, int perPieAmount, string units, bool required = true)
        {
            Name = name;
            AmountPerPie = perPieAmount;
            Units = units;
            Required = required;
        }

        public int CalculateWholePies()
        {
            if(Amount == 0 && !Required){
                return int.MaxValue;
            }

            int numberOfPies = 0;
            if(AmountPerPie > 0)
            {
                double pies = (Amount / AmountPerPie);
                numberOfPies = (int)Math.Floor(pies);
            }
            return numberOfPies;
        }

        public int CalculateLeftovers(int numberOfPies){
            int leftOvers = Amount - (numberOfPies * AmountPerPie);
            return leftOvers;
        }

    }
}