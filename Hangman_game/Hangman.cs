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

        public void SetAttributes(string capital, string country)
        {
            this.Capital = capital;
            this.Country = country;
        }

        public void CheckWord(string word, bool countTries = true)
        {
            if(word.Equals(Capital))
            {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}.");
                this.Win = true;
            }
            else
            {
                this.Hp = this.Hp - 2;
            }
                this.Tries++;
        }

        public void CheckLetter(string word, bool countTries = true)
        {
            if(Capital.Contains(word))
            {
                Console.WriteLine($"This word contains this letter.");
            }
            else
            {
                this.Hp--;
            }
            this.Tries++;
        }

        public bool CheckNotInWord(string letter) //if this method returns true player should have another try to guess without loosing HP
        {
            if(_notInWordList.Contains(letter))
            {
                return true;
            }
            else
            {
                _notInWordList.Add(letter);
                return false;
            }
        }
    }
}
