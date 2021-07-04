using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Hangman_game
    {
    class Program
        {
        public static string FillDashes(char letter, string capital, string Current_Dashes)
            {
            var foundIndexes = new List<int>();
            for (int i = 0; i < capital.Length; i++)
                {
                if (capital[i] == letter)
                    {
                    foundIndexes.Add(i);
                    }
                }
            var aStringBuilder = new StringBuilder(Current_Dashes);
            for (int i = 0; i < foundIndexes.Count; i++)
                {
                aStringBuilder.Remove(foundIndexes[i], 1);
                aStringBuilder.Insert(foundIndexes[i], letter.ToString());
                Current_Dashes = aStringBuilder.ToString();
                }
            Console.WriteLine($"Filled dashes: {Current_Dashes}");
            return Current_Dashes;
            }

        static void Main(string[] args)
            {
            char RS;
            do
                {
                Stopwatch stopwatch = new Stopwatch();
                Console.Clear();
                Console.WriteLine("Welcome to Hangman game!\nYou will have to guess a capital's name.\nPress any key to continue.");
                Console.ReadKey();
                stopwatch.Start();
                string[] list = File.ReadAllLines(@"C:\Users\buats\OneDrive\Pulpit\Motorola Academy\countries_and_capitals.txt");
            int length = list.Length;
            Console.WriteLine($"List's length: {length}");
            String[] splitter = { " | " };
            int splitter_count = 3;
            Random random = new Random();
            int row_num = random.Next(length);
            string[] row = list[row_num].Split(splitter, splitter_count, StringSplitOptions.None);
            Console.WriteLine($"Row number: {row_num}");
            Console.WriteLine($"Country: {row[0]}");
            Console.WriteLine($"Capital: {row[1]}");
            Regex rgx = new Regex("[^ ]");
            string dashes = row[1];
            dashes = rgx.Replace(dashes, "_");
            Console.WriteLine($"Guess a capital\n{dashes}");
            Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");
            Hangman Bob = new Hangman();
            Bob.SetAttributes(row[1], row[0]);
                while (Bob.ReadHP() > 0 & Bob.Win == false)
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
                            dashes = FillDashes(letter_input, Bob.Capital, dashes);
                            Bob.Check(dashes);
                            break;
                        case 'w':
                        case 'W':
                            Console.WriteLine($"You selected word(s)");
                            string input = Console.ReadLine();
                            Bob.Check(input);
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again. Perhaps you pressed the wrong button or again you guessed wrong letter.");
                            break;
                        }
                    }
                stopwatch.Stop();
                Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds/1000}.{stopwatch.ElapsedMilliseconds / 1000}seconds.\nDo you want to try again? Press Y if you want so, if not press any key.");
                RS = Console.ReadKey().KeyChar;
                } while (RS == 'Y' | RS == 'y');
            }
        }
    }
