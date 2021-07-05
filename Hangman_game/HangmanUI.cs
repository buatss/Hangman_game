using System;

namespace Hangman_game
{
    public class HangmanUI
    {
        public void WriteHeader()
        {
            Console.WriteLine("Welcome to Hangman game!\nYou will have to guess a capital's name.\nPress any key to continue.");
        }
        public void ShowDetails(int length,int rowNumber,string country,string key)
        {
            Console.WriteLine($"List's length: {length}");
            Console.WriteLine($"Row number: {rowNumber}");
            Console.WriteLine($"Country: {country}");
            Console.WriteLine($"Capital: {key}");
        }
        public void WriteLoopHeader(string dashes)
        {
            Console.WriteLine($"Guess a capital\n{dashes}");
            Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");
            Console.WriteLine();
        }
    }
}
