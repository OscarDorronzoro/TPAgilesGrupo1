using Hangman.Data.Models;
using System;
using System.Diagnostics;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = new TimerWrapper();
            var game = new Game(time);
            
            Debug.WriteLine("Please, enter your name:");
            var name = Console.ReadLine();
            Console.Clear();
            
            game.Start(name);
            var tries = 7;
           
            Debug.WriteLine("What word will you be guessing? :");
            var word = Console.ReadLine();
            Console.Clear();
            
            game.Config(word, tries);
            while (game.Tries != 0 && !game.Adivina)
            {
                Debug.WriteLine("Guessing letter? :");
                var letter = Console.ReadLine();
                game.Guess(letter);
            }
            Debug.WriteLine($"Fails: {game.Fails}");
        }
    }
}
