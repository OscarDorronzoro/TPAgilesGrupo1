namespace Hangman.Data.Models
{
    public class Games : BaseEntity
    {
        public string Word { get; set; }
        public Users User { get; set; }
    }
}
