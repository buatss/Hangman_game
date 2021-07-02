using System;
using System.IO;

namespace Hangman_game
{
    class Program
    {
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


            string[] row = list[row_num].Split(splitter, splitter_count, StringSplitOptions.None);

            Console.WriteLine($"Row number: {row_num}");
            Console.WriteLine($"Country: {row[0]}");
            Console.WriteLine($"Capital: {row[1]}");
            string dashes ="";
            for (int i=0; i<row[1].Length; i++)
            {
                dashes = dashes + " _";
            }
            Console.WriteLine($"Guess a capital\n{dashes}");

            Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");

            Select: char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

        switch (input)
            {
                case 'l': case 'L':
                    Console.WriteLine($"You selected letter");
                    break;
                case 'w': case'W':
                    Console.WriteLine($"You selected word(s)");
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    goto Select;
            }
            
        }
    }
}
