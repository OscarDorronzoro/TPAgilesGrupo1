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
            //Debug.WriteLine("How many tries do you want to have? :");
            //var tries = Console.ReadLine();
            var tries = 7;
            Debug.WriteLine("What word will you be guessing? :");
            var word = Console.ReadLine();
            Console.Clear();
            //game.Config(word, Int32.Parse(tries));
            game.Config(word, tries);
            while (game.Tries != 0 && game.Adivina == false)
            {
                Debug.WriteLine("Guessing letter? :");
                var letter = Console.ReadLine();
                game.Guess(letter);
            }
            Debug.WriteLine($"Fails: {game.Fails}");
        }
    }
}
