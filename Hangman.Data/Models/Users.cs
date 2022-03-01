using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hangman.Data.Models
{
    public class Users : BaseEntity
    {
        public int Age { get; set; }
        public string Username { get; set; }
    }
}
