using Hangman.Data.Interfaces;
using Hangman.Data.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hangman
{
    public class Game : IGame
    {

        public string Username { get; set; }
        public string Word { get; set; }
        public List<string> RandomWords { get; set; }
        private bool ListOfWords { get; set; }
        public int Tries { get; set; }
        public bool Adivina { get; set; }
        public string Instructions { get; set; }
        public List<string> Attempts { get; set; }
        public int Fails { get; set; }
        public Dictionary<double, int> Score { get; set; }
        private ITimer _Time { get; set; }
        public bool InvalidLetter { get; set; }
        public Game(ITimer timer)
        {
            this.InvalidLetter = false;
            this.Fails = 0;
            this.Attempts = new List<string>();
            this.Score = new Dictionary<double, int>();
            this.Word = null;
            this.Tries = 0;
            this.Adivina = false;
            this._Time = timer;
            this._Time = new TimerWrapper();
            this._Time.Timer.Start();
            this.RandomWords = null;
            this.ListOfWords = false;
        }

        public Game()
        {
            this.InvalidLetter = false;
            this.Fails = 0;
            this.Attempts = new List<string>();
            this.Score = new Dictionary<double, int>();
            this.Word = null;
            this.Tries = 0;
            this.Adivina = false;
            this.RandomWords = null;
            this.ListOfWords = false;
        }
        public IGame Start(string username)
        {
            this.Fails = 0;
            this.Attempts = new List<string>();
            this.Score = new Dictionary<double, int>();
            this.Instructions = "El objetivo de este juego es adivinar la palabra secreta que ha pensado " +
            "el otro jugador. Debes lograrlo antes de ser 'ahorcado'. Para esto debes seguir las siguientes reglas: " +
            "\n1. Puedes adivinar tirando letras al azar. Cada letra erronéa es un intento que se resta. No se permiten números" +
            "\n2. Tienes 6 oportunidades, una correspondiente a cada parte del muñeco que se va a dibujar " +
            "(cabeza, torso, dos brazos, dos piernas). Cuando se terminas los intentos, pierdes." +
            "\n3. Puedes saber la cantidad de letras que posee la palabra a adivinar.";
            this.Word = null;
            this.Tries = 0;
            this.Adivina = false;
            this.RandomWords = null;
            this.ListOfWords = false;
            this.Username = username;
            Debug.WriteLine($"- Game Started - Welcome {this.Username}");

            return this;
        }

        public IGame Config(string word, int tries = 0)
        {
            this.Word = word;
            this.Tries = tries;
            Debug.WriteLine($"- Game Created - Word with {this.Word.Length} letters - Tries {this.Tries}");
            this.ListOfWords = false;

            return this;
        }

        public IGame Config(List<string> words, int tries = 0)
        {
            this.RandomWords = words;
            this.Tries = tries;
            Debug.WriteLine($"- Game Created - Word list with {this.RandomWords.Count} random words  - Tries {this.Tries}");
            ListOfWords = true;

            return this;
        }

        public IGame Guess(string letter)
        {
            if (letter.All(char.IsDigit))
            {
                this.InvalidLetter = true;

                return this;
            }

            bool used = CheckLetter(letter);
            if (used == true)
            {
                Debug.WriteLine("letter already used");
                return this;
            }
            else
            {
                this.Attempts.Add(letter);
                Debug.WriteLine("Letters used");
                foreach (string let in this.Attempts)
                {
                    Debug.WriteLine(let);
                }

                CheckTries(letter);

                CheckWin();

                Debug.WriteLine($"Fails left: {this.Tries}");

                return this;
            }
        }
        public double GetTime()
        {
            return this._Time.GetTimer();
        }

        private void CheckTries(string letter)
        {
            if (this.Tries == 0)
            {
                //Score.Add(this._Time.Timer.Interval, this.Fails);
                Debug.WriteLine($"- You lose - {this.Username}");
                Debug.WriteLine("You run out of tries.");
            }
            if (!Word.Contains(letter))
            {
                this.Tries--;
                this.Fails++;
            }
        }

        public void CheckWin()
        {
            int Cant = Word.Length;
            int aux = 0;
            char[] letters = Word.ToCharArray();
            foreach (string let in this.Attempts)
            {
                if (Word.Contains(let))
                {
                    foreach (char letter in letters)
                    {
                        char letra = char.Parse(let);
                        if (letra == letter)
                        {
                            aux++;
                        }
                    }
                }
            }
            if (aux == Cant)
            {
                this.Adivina = true;
                Debug.WriteLine($"- You win -  {this.Username}");
            }
        }

        public bool CheckLetter(string letter)
        {
            foreach (string let in this.Attempts)
            {
                if (letter == let)
                {
                    return true;
                }
            }
            return false;
        }

    }
}