using System;
using BakerBiz.Model;

namespace BakerBiz.Utilities
{
    public static class InputHelper
    {
        public static bool ParseInputStrings(string input, string inputType, out int result)
        {
            if (string.IsNullOrEmpty(input))
            {
                result = 0;
                return false;
            }

            bool success = int.TryParse(input, out result);

            if (!success)
            {
                Console.WriteLine($"I do not understand \"{input}\" {inputType}. What does that even mean?  Come on MAN!!!");
                Console.WriteLine("Let's try again please.");
            }

            return success;
        }
    }
}