using System;

namespace Hangman_game
{
    public class Hangman
    {
        int HP = 5;
        string Capital;
        string Country;
        void Substract_HP(int amount)
        {
            HP = HP - amount;
            if (HP > 0)
            {
                Console.WriteLine($"You lost {amount} health point(s)");
            }
            else
            {
                Console.WriteLine($"You lost");
            }
        }
        public void get_attributes(string Cp,string Cn)
        {
            Capital = Cp;
            Country = Cn;
        }
       public void check(string word)
        {
            if (word.Equals(Capital))
            {
                Console.WriteLine($"Congratulations! {Capital} is capital of {Country}");
            }
            else if(Capital.Contains(word))
                {
                Console.WriteLine($"Capital contains this letter");
            }
            else if (word.Length>1)
            {
                Substract_HP(2);
            }
            else if(word.Length==1)
            {
                Substract_HP(1);
            }
        }
    }
}
