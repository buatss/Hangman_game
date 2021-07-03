﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Hangman_game
{

    class Program
    {

        public static string Fill_Dashes(char letter, string capital,string Current_Dashes)
        {
            //int count = capital.Count(f => (f==letter));
            //Console.WriteLine($"Count: {count}");

            var foundIndexes = new List<int>();
            for (int i=0; i<capital.Length;i++)
            {
                if (capital[i] == letter)
                    foundIndexes.Add(i);
            }
            foreach(int index in foundIndexes)
            {
                /*
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"List's count: {foundIndexes.Count}");
                */

                var aStringBuilder = new StringBuilder(Current_Dashes);
                for (int i=0;i<foundIndexes.Count;i++)
                {
                    
                    aStringBuilder.Remove(foundIndexes[i], 1);
                    aStringBuilder.Insert(foundIndexes[i], letter.ToString());
                    Current_Dashes = aStringBuilder.ToString();
                }
                
              
            }
            Console.WriteLine($"Filled dashes: {Current_Dashes}");
            return Current_Dashes;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Hangman game!");
            string[] list = File.ReadAllLines(@"C:\Users\buats\OneDrive\Pulpit\Motorola Academy\countries_and_capitals.txt");

            int length = list.Length;
            Console.WriteLine($"List's length: {length}");
            String[] splitter = { " | " };
            int splitter_count = 3;

            Random random = new Random();
            int row_num = random.Next(length);

            row_num = 55;


           string[] row = list[row_num].Split(splitter, splitter_count, StringSplitOptions.None);

            Console.WriteLine($"Row number: {row_num}");
            Console.WriteLine($"Country: {row[0]}");
            Console.WriteLine($"Capital: {row[1]}");
            Regex rgx = new Regex("[^ ]");
            string dashes = row[1];
            dashes = rgx.Replace(dashes,"_");



            Console.WriteLine($"Guess a capital\n{dashes}");

            Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");

            Hangman Bob = new Hangman();
            Bob.SetAttributes(row[1], row[0]);
            while (Bob.ReadHP()>0)
            {
            char select_input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (select_input)
                {
                    case 'l':
                    case 'L':
                        Console.WriteLine($"You selected letter");
                        char letter_input = Console.ReadKey().KeyChar;
                        string letter_input2 = letter_input.ToString();
                        Bob.Check(letter_input2);
                        dashes=Fill_Dashes(letter_input,Bob.Capital,dashes);
                        break;
                    case 'w':
                    case 'W':
                        Console.WriteLine($"You selected word(s)");
                        string input = Console.ReadLine();
                        Bob.Check(input);
                        break;
                    default:
                        Console.WriteLine("Wrong input, try again");
                        break;
                }
            }
            
        }
    }
}
