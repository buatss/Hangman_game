using System;
using System.Collections.Generic;

namespace Hangman_game
{
    public class Hangman
    {
        public int hp { get; private set; } = 5;
        public int tries { get; private set; } = 0;
        public bool? win { get; private set; }
        public List<string> notInWordList = new List<string>();
        public string capital { get; private set; }
        public string country { get; private set; }

        public void SubstractHP(int amount)
        {
            hp -=amount;
            if(hp > 0)
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
            this.capital = capital;
            this.country = country;
        }

        public void Check(string word, bool countTries = true)
        {
            if(word.Equals(capital))
            {
                Console.WriteLine($"Congratulations! {capital} is capital of {country}.");
                this.win = true;
            }
            else if(capital.Contains(word))
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
                this.tries++;
            }
        }

        public bool CheckNotInWord(string letter) //if this method returns true player should have another try to guess without loosing HP
        {
            if(this.notInWordList.Contains(letter))
            {
                return true;
            }
            else
            {
                this.notInWordList.Add(letter);
                return false;
            }
        }
    }
}
