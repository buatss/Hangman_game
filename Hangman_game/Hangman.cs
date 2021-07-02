﻿using System;

namespace Hangman_game
{
    public class Hangman
    {
        private int _hp = 5;
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

        public void SetAttributes(string capitol, string country)
        {
            this.Capital = capitol;
            this.Country = country;
        }

        public void Check(string word)
        {
            if (word.Equals(Capital))
            {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}");
            }
            else if (Capital.Contains(word))
            {
                Console.WriteLine($"Capital contains this letter");
            }
            else if (word.Length > 1)
            {
                this.SubstractHP(2);
            }
            else if (word.Length == 1)
            {
                this.SubstractHP(1);
            }
        }
        public int ReadHP()
        {
            return this._hp;
        }
    }


}
