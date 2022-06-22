using System;

namespace Interview_Refactor1
{
    public class PieRecipeCalculationResults
    {
        public int NumApples {get; set;}
        public int SugarLbs {get; set;}
        public int FlourLbs {get; set;}
        public int NumPies {get; set;}
               
        public int LeftOverApples {get; set;}
        public int LeftOverSugarLbs {get; set;}
        public int LeftOverFlourLbs {get; set;}

        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(LeftOverApples);
            builder.Append(" apple(s) left over, ");
            builder.Append(LeftOverSugarLbs);
            builder.Append(" lbs sugar left over, ");
            builder.Append(LeftOverFlourLbs);
            builder.Append(" lbs flour left over.");
            return builder.ToString();
        }
    }
}