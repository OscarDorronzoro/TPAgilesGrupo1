using Hangman.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Hangman.Data.Models
{
    public class TimerWrapper : ITimer
    {
        public Timer Timer { get; set; }

        public TimerWrapper()
        {
            Timer = new Timer();
        }
        public double GetTimer()
        {
            return Timer.Interval;
        }
    }
}
