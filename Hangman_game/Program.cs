using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Hangman_game
{
    partial class Program
    {
        static void Main(string[] args)
        {
            HangmanUI userMessages = new HangmanUI();
            do
            {
                Hangman theGame = new Hangman();
                Stopwatch stopwatch = new Stopwatch();
                Console.Clear();
                userMessages.WriteHeader();
                Console.ReadKey();
                stopwatch.Start();
                string[] list = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt");
                int length = list.Length;
                String[] splitter = { " | " };
                int splitterCount = 3;
                Random random = new Random();
                int rowNumber = random.Next(length);
                string[] row = list[rowNumber].Split(splitter, splitterCount, StringSplitOptions.None);

                userMessages.ShowDetails(length, rowNumber, row[1], row[0]); //this is for developer

                Regex rgx = new Regex("[^ ]");
                string dashes = row[1];
                dashes = rgx.Replace(dashes, "_");

                theGame.SetAttributes(row[1], row[0]);
                while(theGame.Hp > 0 & theGame.Win == null)
                {
                    userMessages.WriteLoopHeader(dashes);

                    string caseOutput;
                    switch(ProgramBase.GetUserInput())
                    {
                        case "L":
                            Console.WriteLine($"Insert letter: ");
                            char letterInput = Console.ReadKey().KeyChar;
                            caseOutput = letterInput.ToString();
                            if(theGame.LetterValidator(caseOutput, dashes))
                            {
                                dashes = ProgramBase.FillDashes(letterInput, theGame.Capital, dashes);
                            }
                            break;
                        case "W":
                            Console.WriteLine($"Insert word(s): ");
                            caseOutput = Console.ReadLine();
                            if(theGame.CheckWord(caseOutput) == true)
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
                    else if(theGame.HpCost > 0)
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
                switch(ProgramBase.GetUserInput())
                {
                    case "Y":
                        Console.WriteLine("Enter your nickname:");
                        string nickname = Console.ReadLine();
                        string splitter2 = " | ";
                        string score = nickname + splitter2 + localDate + splitter2 + stopwatch.ElapsedMilliseconds / 1000 + "." + stopwatch.ElapsedMilliseconds / 1000 + "s" + splitter2 + theGame.Tries + splitter2 + theGame.Capital;
                        Console.WriteLine($"Score: {score}");
                        File.AppendAllText("..\\..\\..\\scores.txt", "\n" + score);
                        break;
                }
                Console.WriteLine("Press Y to try again or any other key to continue.");
            } while(ProgramBase.GetUserInput().Contains("Y"));
        }
    }
}
