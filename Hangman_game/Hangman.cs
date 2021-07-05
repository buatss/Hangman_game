using System;
using System.Collections.Generic;

namespace Hangman_game
{
    public class Hangman
    {
        public int Hp { get; private set; } = 5;
        public int hpCost { get; private set; }
        public int Tries { get; private set; } = 0;
        public bool? Win { get; set; }
        public List<string> _notInWordList = new List<string>();
        public string Capital { get; private set; }
        public string Country { get; private set; }

        public void SetAttributes(string capital, string country)
        {
            this.Capital = capital;
            this.Country = country;
        }

        public bool CheckWord(string word, bool countTries = true)
        {
            this.Tries++;
            if(word.Equals(Capital))
            {
                this.hpCost = 0;
                return true;
            }
            else
            {
                hpCost = 2;
                this.Hp -= this.hpCost;
                return false;
            }
        }

        public bool CheckLetter(string word, bool countTries = true)
        {
            this.Tries++;
            if(Capital.Contains(word))
            {
                this.hpCost = 0;
                return true;
            }
            else
            {
                hpCost = 1;
                this.Hp -= hpCost;
                return false;
            }
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
