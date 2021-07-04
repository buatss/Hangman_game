using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hangman_game
{
    internal class ProgramBase
    {
        public static string FillDashes(char letter, string capital, string Current_Dashes)
        {
            var foundIndexes = new List<int>();
            for(int i = 0; i < capital.Length; i++)
            {
                if(capital[i] == letter)
                {
                    foundIndexes.Add(i);
                }
            }
            var aStringBuilder = new StringBuilder(Current_Dashes);
            for(int i = 0; i < foundIndexes.Count; i++)
            {
                aStringBuilder.Remove(foundIndexes[i], 1);
                aStringBuilder.Insert(foundIndexes[i], letter.ToString());
                Current_Dashes = aStringBuilder.ToString();
            }
            Console.WriteLine($"Filled dashes: {Current_Dashes}");
            return Current_Dashes;
        }

        public static string CharToUpperString(char charArgument)
        {
            string upperString;
            upperString = charArgument.ToString();
            upperString = upperString.ToUpper(new CultureInfo("en-US", false));
            return upperString;
        }
    }
}