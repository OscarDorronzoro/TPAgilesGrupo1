using System.Collections.Generic;

namespace Hangman.Web.Models
{
    public class GameViewModel
    {
        public string Name { get; set; }
        public int Tries { get; set; }
        public string Word { get; set; }
        public string Instructions { get; set; }
        public List<string> Attemps { get; set; }
        public bool Lose { get; set; }
        public bool Win { get; set; }
    }
}
