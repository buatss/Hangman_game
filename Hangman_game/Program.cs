using System;

namespace Hangman_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman game!");
            string[] list = System.IO.File.ReadAllLines(@"C:\Users\buats\OneDrive\Pulpit\Motorola Academy\countries_and_capitals.txt");

            int X = list.GetLength(0);
          
            Console.WriteLine($"Length: {X}");
            string[] row = list[1].Split('|');

            foreach (var word in row)
            {
                System.Console.WriteLine($"{word}");
            }


        }
    }
}
