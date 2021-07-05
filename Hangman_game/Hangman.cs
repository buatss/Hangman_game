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
        public List<string> _notInWordList = new List<string>();
        public string Capital { get; private set; }
        public string Country { get; private set; }
        public void ControlHp()
        {
            Hp-=HpCost;
        }
        public bool Validator(string letter)
        {
            if(CheckLetter(letter)==true)
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

        public bool CheckLetter(string letter)
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

        public bool CheckNotInWord(string letter)
        {
            if(_notInWordList.Contains(letter))
            {
                HpCost = 0;
                return true;
            }
            else
            {
                _notInWordList.Add(letter);
                Tries++;
                HpCost = 1;
                return false;
            }
        }
    }
}
