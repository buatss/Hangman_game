﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;

namespace Hangman_game
{
    class Program
    {
       

        static void Main(string[] args)
        {
            char resetChar; char charInput;
            do
            {
                Stopwatch stopwatch = new Stopwatch();
                Console.Clear();
                Console.WriteLine("Welcome to Hangman game!\nYou will have to guess a capital's name.\nPress any key to continue.");
                Console.ReadKey();
                stopwatch.Start();

                string[] list = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt");
                int length = list.Length;

                Console.WriteLine($"List's length: {length}");

                String[] splitter = { " | " };
                int splitterCount = 3;
                Random random = new Random();
                int rowNumber = random.Next(length);
                string[] row = list[rowNumber].Split(splitter, splitterCount, StringSplitOptions.None);

                Console.WriteLine($"Row number: {rowNumber}");
                Console.WriteLine($"Country: {row[0]}");
                Console.WriteLine($"Capital: {row[1]}");

                Regex rgx = new Regex("[^ ]");
                string dashes = row[1];
                dashes = rgx.Replace(dashes, "_");

                Console.WriteLine($"Guess a capital\n{dashes}");
                Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");

                Hangman theGame = new Hangman();
                theGame.SetAttributes(row[1], row[0]);
                while(theGame.hp > 0 & theGame.win == null)
                {
                    charInput = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch(ProgramBase.CharToUpperString(charInput))
                    {
                        case "L":
                            Console.WriteLine($"You selected letter");
                            char letterInput = Console.ReadKey().KeyChar;

                            theGame.Check(letterInput.ToString());
                            dashes = ProgramBase.FillDashes(letterInput, theGame.capital, dashes);
                            theGame.Check(dashes, false);
                            break;
                        case "W":
                            Console.WriteLine($"You selected word(s)");
                            string input = Console.ReadLine();
                            theGame.Check(input);
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again. Perhaps you pressed the wrong button or again you guessed wrong letter.");
                            break;
                    }
                }

                stopwatch.Stop();
                DateTime localDate = DateTime.Now;
                Console.WriteLine($"You tried to guess {theGame.tries} time(s) in {stopwatch.ElapsedMilliseconds / 1000}.{stopwatch.ElapsedMilliseconds / 1000}seconds.");
                Console.WriteLine("Do you wish to save your score? Press Y to do so or any other key to continue.");
                charInput = Console.ReadKey().KeyChar;
                switch(ProgramBase.CharToUpperString(charInput))
                {
                    case "Y":
                        Console.WriteLine("Enter your nickname:");
                        string nickname = Console.ReadLine();
                        string splitter2 = " | ";
                        string score = nickname + splitter2 + localDate + splitter2 + stopwatch.ElapsedMilliseconds / 1000 + "." + stopwatch.ElapsedMilliseconds / 1000 + "s" + splitter2 + theGame.tries + splitter2 + theGame.capital;
                        Console.WriteLine($"Score: {score}");
                        File.WriteAllText("..\\..\\..\\scores.txt", score);
                        break;
                }
                Console.WriteLine("Press Y to try again or any other key to continue.");
                resetChar = Console.ReadKey().KeyChar;
            } while(ProgramBase.CharToUpperString(resetChar) == "Y");
        }
    }
}
