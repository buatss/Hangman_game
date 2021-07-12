using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman_game
{
    internal class ProgramBase
    {
        public static string FillDashes(string letter, string capital, string currentDashes)
        {
            int j = 0;
            do
            {
                var foundIndexes = new List<int>();
                for(int i = 0; i < capital.Length; i++)
                {
                    if(capital[i] == letter[0])
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
                letter = letter.ToLower();
                j++;
            } while(j < 2);
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

        public static Tuple<string,string> GetRandomRow(int length)
        {
            //string[] list = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt");
            //int length = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt").Length;
            String[] splitter = { " | " };
            int splitterCount = splitter[0].Length;
            Random random = new Random();
            int rowNumber = random.Next(length);
            string line = File.ReadLines("..\\..\\..\\countries_and_capitals.txt").Skip(rowNumber-1).Take(1).First();
            string[] row = line.Split(splitter, splitterCount, StringSplitOptions.None);
            return Tuple.Create(row[1], row[0]);
        }
    }
}