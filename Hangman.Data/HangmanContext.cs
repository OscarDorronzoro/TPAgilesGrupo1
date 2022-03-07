using Hangman.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Data
{
    public class HangmanContext : DbContext
    {
        public HangmanContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Age = 28,
                    Username = "Hernan"
                },
                new Users
                {
                    Id = 2,
                    Age = 23,
                    Username = "Oscar"
                },
                new Users
                {
                    Id = 3,
                    Age = 21,
                    Username = "Agustina"
                });
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Games> Games { get; set; }
    }
}
