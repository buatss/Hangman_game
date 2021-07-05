using System;
using System.Collections.Generic;

namespace Hangman_game
{
    public class Hangman
    {
        public int Hp { get; private set; } = 5;
        public int HpCost { get; private set; }
        public int Tries { get; private set; } = 0;
        public bool? Win { get; set; }
        public List<string> NotInWordList { get; private set; } = new List<string>();
        public string Capital { get; private set; }
        public string Country { get; private set; }
        public void ControlHp()
        {
            Hp-=HpCost;
        }
        public bool LetterValidator(string letter, string currentDashes)
        {
            if(CheckLetter(letter) & !currentDashes.Contains(letter))
            {
                Tries++;
                HpCost = 0;
                return true;
            }
            else
            {
                CheckNotInWord(letter);
                return false;
            }
 
        }
        public void SetAttributes(string capital, string country)
        {
            this.Capital = capital;
            this.Country = country;
        }

        public bool CheckWord(string word)
        {
            this.Tries++;
            if(word.Equals(Capital))
            {
                return true;
            }
            else
            {
                HpCost = 2;
                return false;
            }
        }

        private bool CheckLetter(string letter)
        {
            if(Capital.Contains(letter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckNotInWord(string letter)
        {
            if(!NotInWordList.Contains(letter) & !Capital.Contains(letter))
            {
                NotInWordList.Add(letter);
                Tries++;
                HpCost = 1;
            }
            else
            {
                HpCost = 0;
            }
        }
    }
}
