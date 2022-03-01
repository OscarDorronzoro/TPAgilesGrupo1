using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Web.Models
{
    public class GuesLetterViewModel
    {
        public string Letter { get; set; }
        public int GameId { get; set; }
    }
}
