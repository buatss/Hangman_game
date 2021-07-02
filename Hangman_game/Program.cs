using System;
using System.IO;
using System.Text.RegularExpressions;

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
