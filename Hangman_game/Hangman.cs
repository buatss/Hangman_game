using System;
using System.Collections.Generic;

namespace Hangman_game
{
    public class Hangman
    {
        public int Hp { get; private set; } = 5;
        public int Tries { get; private set; } = 0;
        public bool? Win { get; private set; }
        public List<string> _notInWordList = new List<string>();
        public string Capital { get; private set; }
        public string Country { get; private set; }

        public void SubstractHP(int amount)
        {
            Hp -=amount;
            if(Hp > 0)
            {
                Console.WriteLine($"You lost {amount} health point(s)");
            }
            else
            {
                Console.WriteLine($"You lost");
            }
        }

        public void SetAttributes(string capital, string country)
        {
            this.Capital = capital;
            this.Country = country;
        }

        public void Check(string word, bool countTries = true)
        {
            if(word.Equals(Capital))
            {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}.");
                this.Win = true;
            }
            else if(Capital.Contains(word))
            {
                if(CheckNotInWord(word) == false)
                {
                    Console.WriteLine($"Capital contains this letter");
                }
            }
            else if(word.Length > 1 & word.Contains("_") == false)
            {
                this.SubstractHP(2);
            }
            else if(word.Length == 1 & word.Contains("_") == false)
            {
                if(CheckNotInWord(word) == false)
                {
                    this.SubstractHP(1);
                }
            }
            if(countTries == true)
            {
                this.Tries++;
            }
        }

        public bool CheckNotInWord(string letter) //if this method returns true player should have another try to guess without loosing HP
        {
            if(this._notInWordList.Contains(letter))
            {
                return true;
            }
            else
            {
                this._notInWordList.Add(letter);
                return false;
            }
        }
    }
}
