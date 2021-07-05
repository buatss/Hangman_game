using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hangman_game
{
    internal class ProgramBase
    {
        public static string FillDashes(char letter, string capital, string currentDashes)
        {
            var foundIndexes = new List<int>();
            for(int i = 0; i < capital.Length; i++)
            {
                if(capital[i] == letter)
                {
                    foundIndexes.Add(i);
                }
            }
            var aStringBuilder = new StringBuilder(currentDashes);
            for(int i = 0; i < foundIndexes.Count; i++)
            {
                aStringBuilder.Remove(foundIndexes[i], 1);
                aStringBuilder.Insert(foundIndexes[i], letter.ToString());
                currentDashes = aStringBuilder.ToString();
            }
            //Console.WriteLine($"Filled dashes: {currentDashes}");
            return currentDashes;
        }

        public static string GetUserInput()
        {
            char Input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            string upperString;
            upperString = Input.ToString();
            upperString = upperString.ToUpper(new CultureInfo("en-US", false));
            return upperString;
        }
    }
}