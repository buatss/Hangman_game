using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Hangman_game
{
    class Program
    {
       

        static void Main(string[] args)
        {

            do
            {
                Stopwatch stopwatch = new Stopwatch();
                Console.Clear();
                Console.WriteLine("Welcome to Hangman game!\nYou will have to guess a capital's name.\nPress any key to continue.");
                Console.ReadKey();
                stopwatch.Start();

                string[] list = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt");
                int length = list.Length;
                String[] splitter = { " | " };
                int splitterCount = 3;
                Random random = new Random();
                int rowNumber = random.Next(length);
                string[] row = list[rowNumber].Split(splitter, splitterCount, StringSplitOptions.None);

                Console.WriteLine($"List's length: {length}");
                Console.WriteLine($"Row number: {rowNumber}");
                Console.WriteLine($"Country: {row[0]}");
                Console.WriteLine($"Capital: {row[1]}");

                Regex rgx = new Regex("[^ ]");
                string dashes = row[1];
                dashes = rgx.Replace(dashes, "_");

                Hangman theGame = new Hangman();
                theGame.SetAttributes(row[1], row[0]);
                while(theGame.Hp > 0 & theGame.Win == null)
                {
                    Console.WriteLine($"Guess a capital\n{dashes}");
                    Console.WriteLine($"Do you wish to guess letter or word? Press 'L' for letter or 'W' for word(s).");
                    Console.WriteLine();

                    string caseOutput;
                    switch(ProgramBase.ReadCharThenToUpperString())
                    {
                        case "L":
                            Console.WriteLine($"Insert letter: ");
                            char letterInput = Console.ReadKey().KeyChar;
                            caseOutput = letterInput.ToString();
                            if(theGame.LetterValidator(caseOutput, dashes) == true)
                            {
                                dashes = ProgramBase.FillDashes(letterInput, theGame.Capital, dashes);
                            }
                            break;
                        case "W":
                            Console.WriteLine($"Insert word(s): ");
                            caseOutput = Console.ReadLine();
                            if (theGame.CheckWord(caseOutput)==true)
                            {
                                dashes = theGame.Capital;
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong input, try again. Perhaps you pressed the wrong button or again you guessed wrong letter.");
                            break;
                    }
                    theGame.ControlHp();
                    if(dashes.Contains(theGame.Capital))
                    {
                        theGame.Win = true;
                        Console.WriteLine($"Congratulations! {theGame.Capital} is capital of {theGame.Country}.");
                    }
                    else if(theGame.HpCost>0)
                    {
                        Console.WriteLine($"\nWrong guess, this cost you {theGame.HpCost} life points");
                        Console.WriteLine($"Not-in-word: {String.Join(", ", theGame.NotInWordList.ToArray())}");
                    }
                }

                stopwatch.Stop();
                DateTime localDate = DateTime.Now;
                Console.WriteLine($"You tried to guess {theGame.Tries} time(s) in {stopwatch.ElapsedMilliseconds / 1000}.{stopwatch.ElapsedMilliseconds / 1000}seconds.");
                Console.WriteLine("Do you wish to save your score? Press Y to do so or any other key to continue.");
                Console.WriteLine();
                switch(ProgramBase.ReadCharThenToUpperString())
                {
                    case "Y":
                        Console.WriteLine("Enter your nickname:");
                        string nickname = Console.ReadLine();
                        string splitter2 = " | ";
                        string score = nickname + splitter2 + localDate + splitter2 + stopwatch.ElapsedMilliseconds / 1000 + "." + stopwatch.ElapsedMilliseconds / 1000 + "s" + splitter2 + theGame.Tries + splitter2 + theGame.Capital;
                        Console.WriteLine($"Score: {score}");
                        File.AppendAllText("..\\..\\..\\scores.txt", "\n"+score);
                        break;
                }
                Console.WriteLine("Press Y to try again or any other key to continue.");
            } while(ProgramBase.ReadCharThenToUpperString().Contains("Y"));
        }
    }
}
