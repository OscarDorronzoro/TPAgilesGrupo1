using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Hangman.Data.Interfaces
{
    public interface ITimer
    {
        Timer Timer { get; set; }

        double GetTimer();
    }
}
