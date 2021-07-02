using System;
using System.IO;

namespace Hangman_game
{
    public class Hangman
    {
        int HP = 5;
        string Capital;
        string Country;
        void Substract_HP(int amount)
        {
            HP = HP - amount;
            if (HP > 0)
            {
                Console.WriteLine($"You lost {amount} health point(s)");
            }
            else
            {
                Console.WriteLine($"You lost");
            }
        }
        public void get_attributes(string Cp,string Cn)
        {
            Capital = Cp;
            Country = Cn;
        }
       public void check(string word)
        {
            if (word.Contains(Capital))
            {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}");
            }
            else if(Capital.Contains(word))
                {
                Console.WriteLine($"Capital contains this letter");
            }
            else if (word.Length>1)
            {
                Substract_HP(2);
            }
            else if(word.Length==1)
            {
                Substract_HP(1);
            }
        }
    }
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

            Hangman Bob = new Hangman();
            Bob.get_attributes(row[1], row[0]);

        Select: char select_input = Console.ReadKey().KeyChar;
            Console.WriteLine();

        switch (select_input)
            {
                case 'l': case 'L':
                    Console.WriteLine($"You selected letter");
                    char letter_input = Console.ReadKey().KeyChar;
                    string letter_input2 = letter_input.ToString();
                    Bob.check(letter_input2);
                    break;
                case 'w': case'W':
                    Console.WriteLine($"You selected word(s)");
                    string input = Console.ReadLine();
                    Bob.check(input);
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    goto Select;
            }
            
        }
    }
}
