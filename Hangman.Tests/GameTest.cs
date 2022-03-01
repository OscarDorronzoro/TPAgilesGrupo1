using System.Collections.Generic;
using Xunit;
using Moq;
using Hangman.Data.Interfaces;

namespace Hangman.Test
{
    public class GameTest {

        private readonly IGame _game;
        private readonly Mock<ITimer> _time;
        public GameTest()
        {
            _time = new Mock<ITimer>();
            _time.Setup(x => x.GetTimer()).Returns(1);
            _game = new Game(_time.Object);
        }

        [Theory]
        [InlineData("Hernan")]
        public void UserInformationTest(string username)
        {
            _game.Start(username);
            Assert.Equal("Hernan", _game.Username);
        }

        [Theory]
        [InlineData("H3rn4n")]
        public void UserInformationNameWithNumberTest(string username)
        {
            _game.Start(username);
            Assert.Equal("H3rn4n", _game.Username);
        }

        [Theory]
        [InlineData("")]
        public void UserInformationEmptyNameTest(string username)
        {
            _game.Start(username);
            Assert.Equal("", _game.Username);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria")]
        public void CreateNewGameWithWordTest(string username, string word) {
            _game.Start(username).Config(word);
            Assert.Equal("Ingenieria", _game.Word);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", "I")]
        public void InsertLetterTest(string username, string word, string letter) {
            _game.Start(username).Config(word).Guess(letter);
            Assert.Equal(_game.Attempts[0], letter);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", "5")]
        public void InsertNumberTest(string username, string word, string letter)
        {
            _game.Start(username).Config(word).Guess(letter);
            Assert.True(_game.InvalidLetter, letter);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", "I")]
        public void CorrectLetterTest(string username, string word, string letter) {
            _game.Start(username).Config(word).Guess(letter);
            Assert.Equal(0, _game.Fails);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", "D")]
        public void NumberOfFailsTest(string username, string word, string letter) {
            _game.Start(username).Config(word).Guess(letter);
            Assert.Equal(1, _game.Fails);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", 1, "I")]
        public void SingleGameScoreTest(string username, string word, int tries, string letter)
        {

            _game.Start(username).Config(word, tries).Guess(letter);
            Assert.Equal(_game.Attempts, new List<string> { "I" });
            Assert.Equal(0, _game.Fails);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", new string[] { "I", "n", "g", "e", "i", "i", "e", "r", "i", "a" })]
        public void CheckWinTest(string username, string word, string[] letters)
        {
            _game.Start(username).Config(word);
            foreach (var letter in letters)
            {
                _game.Guess(letter);
            }
            Assert.True(_game.Adivina);
        }

        [Theory]
        [InlineData("Hernan", "Ingenieria", "El objetivo de este juego es adivinar la palabra secreta que ha pensado " +
            "el otro jugador. Debes lograrlo antes de ser 'ahorcado'. Para esto debes seguir las siguientes reglas: " +
            "\n2. Puedes adivinar tirando letras al azar. Cada letra erronéa es un intento que se resta. No se permiten números" +
            "\n3. Tienes 6 oportunidades, una correspondiente a cada parte del muñeco que se va a dibujar " +
            "(cabeza, torso, dos brazos, dos piernas). Cuando se terminas los intentos, pierdes." +
            "\n4. Puedes saber la cantidad de letras que posee la palabra a adivinar.")]
        public void ValidateInstructions(string username, string word, string instructions)
        {
            _game.Start(username).Config(word);

            Assert.Equal(_game.Instructions, instructions);
        }
    }
}