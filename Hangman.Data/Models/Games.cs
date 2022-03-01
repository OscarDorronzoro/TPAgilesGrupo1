using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hangman.Data.Models
{
    public class Games : BaseEntity
    {
        public string Word { get; set; }
        public Users User { get; set; }
    }
}
