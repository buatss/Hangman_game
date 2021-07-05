﻿using System;
using System.Linq;

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
        public void WriteAskLetter()
        {
            Console.WriteLine($"Insert letter: ");
        }
        public void WriteAskWord()
        {
            Console.WriteLine($"Insert word(s): ");
        }
        public void WriteWrongInput()
        {
            Console.WriteLine("Wrong input, try again. Perhaps you pressed the wrong button or again you guessed wrong letter.");
        }
        
        public void WriteWrongAnswer(int hpCost,string NotInWordList)
        {
            Console.WriteLine($"\nWrong guess, this cost you {hpCost} life points");
            Console.WriteLine($"Not-in-word: {String.Join(", ", NotInWordList)}");
        }

        public void WriteAfterLoop(int tries,long time)
        {
            Console.WriteLine($"You tried to guess {tries} time(s) in {time/1000}.{time/10}seconds.");
            Console.WriteLine("Do you wish to save your score? Press Y to do so or any other key to continue.");
            Console.WriteLine();
        }

        public void AskNickname()
        {
            Console.WriteLine("Enter your nickname:");
        }

        public void WriteScore(string score)
        {
            Console.WriteLine($"Your score: {score}");
        }

        public void AskReset()
        {
            Console.WriteLine("Press Y to try again or any other key to continue.");
        }
        public void WriteDefeat(string capital,string country)
        {
            Console.WriteLine($"Unfortunatly, you didn't make it. You keyword was {capital} - capital of {country}");
        }
    }
}
