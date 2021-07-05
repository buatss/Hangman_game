﻿using System;
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

                //userMessages.ShowDetails(length, rowNumber, row[0], row[1]); //this is for developer

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
                            userMessages.WriteAskLetter();
                            char letterInput = Console.ReadKey().KeyChar;
                            caseOutput = letterInput.ToString();
                            if(theGame.LetterValidator(caseOutput, dashes))
                            {
                                dashes = ProgramBase.FillDashes(letterInput, theGame.Capital, dashes);
                            }
                            break;
                        case "W":
                            userMessages.WriteAskWord();
                            caseOutput = Console.ReadLine();
                            if(theGame.CheckWord(caseOutput) == true)
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
