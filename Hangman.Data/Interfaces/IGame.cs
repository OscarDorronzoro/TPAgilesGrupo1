using System;
using System.Collections.Generic;
using System.Timers;

namespace Hangman.Data.Interfaces
{
    public interface IGame {
        IGame Start(string username);
        IGame Config(string word, int tries = 0);
        IGame Config(List<string> word, int tries = 0);
        IGame Guess(string letter);
        double GetTime();
        string Username { get; set; }
        string Word { get; set; }
        List<string> RandomWords { get; set; }
        List<string> Attempts { get; set; }
        bool Adivina { get; set; }
        string Instructions { get; set; }
        int Fails { get; set; }
        Dictionary<double, int> Score { get; set; }
        int Tries { get; set; }
        bool InvalidLetter { get; set; }
    }
    
}