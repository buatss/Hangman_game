using System;
using System.Collections.Generic;

namespace Hangman_game
    {
    public class Hangman
        {
        private int _hp = 5;
        public bool Win { get; private set; }
        public List<string> NotInWordList = new List<string>();
        public string Capital { get; private set; }
        public string Country { get; private set; }

        public void SubstractHP(int amount)
            {
            _hp = _hp - amount;
            if (_hp > 0)
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

        public void Check(string word)
            {
            if (word.Equals(Capital))
                {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}");
                this.Win = true;
                }
            else if (Capital.Contains(word))
                {
                if (CheckNotInWord(word) == false)
                    {
                    Console.WriteLine($"Capital contains this letter");
                    }
                }
            else if (word.Length > 1 & word.Contains("_") == false)
                {
                this.SubstractHP(2);
                }
            else if (word.Length == 1 & word.Contains("_") == false)
                {
                if (CheckNotInWord(word) == false)
                    {
                    this.SubstractHP(1);
                    }
                }
            }

        public int ReadHP()
            {
            return this._hp;
            }

        public bool CheckNotInWord(string letter) //if this method returns true player should have another try to guess without loosing HP
            {
            if (this.NotInWordList.Contains(letter))
                {
                return true;
                }
            else
                {
                this.NotInWordList.Add(letter);
                return false;
                }
            }
        }
    }
