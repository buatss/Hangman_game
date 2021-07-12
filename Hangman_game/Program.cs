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
            int length = File.ReadAllLines("..\\..\\..\\countries_and_capitals.txt").Length;
            HangmanUI userMessages = new HangmanUI();
            do
            {
                Hangman theGame = new Hangman();
                Stopwatch stopwatch = new Stopwatch();
                Console.Clear();
                userMessages.WriteHeader();
                Console.ReadKey();
                stopwatch.Start();
                string[] row = ProgramBase.GetRandomRow(length);
                userMessages.ShowDetails(length, 0, row[0], row[1]); //this is for developer

                Regex rgx = new Regex("[^ ]");
                string dashes = row[1];
                dashes = rgx.Replace(dashes, "_");

                theGame.SetAttributes(row[1], row[0]);
                while(theGame.Hp > 0 & theGame.Win == null)
                {
                    userMessages.WriteLoopHeader(dashes);
                    switch(ProgramBase.GetUserInput())
                    {
                        case "L":
                            userMessages.WriteAskLetter();
                            //char letterInput = Console.ReadKey().KeyChar;
                            //caseOutput = letterInput.ToString();
                            string userInput = ProgramBase.GetUserInput();
                            if(theGame.LetterValidator(userInput, dashes))
                            {
                                dashes = ProgramBase.FillDashes(userInput, theGame.Capital, dashes);
                            }
                            break;
                        case "W":
                            userMessages.WriteAskWord();
                            if(theGame.CheckWord(Console.ReadLine()) == true)
                            {
                                dashes = theGame.Capital;
                            }
                            break;
                        default:
                            userMessages.WriteWrongInput();
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
                        userMessages.WriteWrongAnswer(theGame.HpCost, String.Join(", ", theGame.NotInWordList.ToArray()));
                    }
                    if(theGame.Hp<=0)
                    {
                        userMessages.WriteDefeat(theGame.Capital,theGame.Country);
                    }
                }

                stopwatch.Stop();
                DateTime localDate = DateTime.Now;
                userMessages.WriteAfterLoop(theGame.Tries, stopwatch.ElapsedMilliseconds);
                switch(ProgramBase.GetUserInput())
                {
                    case "Y":
                        userMessages.AskNickname();
                        string nickname = Console.ReadLine();
                        string splitter2 = " | ";
                        string score = nickname + splitter2 + localDate + splitter2 + stopwatch.ElapsedMilliseconds / 1000 + "." + stopwatch.ElapsedMilliseconds / 10 + "s" + splitter2 + theGame.Tries + splitter2 + theGame.Capital;
                        userMessages.WriteScore(score);
                        File.AppendAllText("..\\..\\..\\scores.txt", "\n" + score);
                        break;
                }
                userMessages.AskReset();
            } while(ProgramBase.GetUserInput().Contains("Y"));
        }
    }
}
