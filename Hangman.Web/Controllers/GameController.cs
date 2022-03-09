using Hangman.Data.Interfaces;
using Hangman.Data.Models;
using Hangman.infrastructure.Repository;
using Hangman.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Hangman.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGame _game;
        private readonly IRepository<Games> _gameRepo;
        private readonly IRepository<Users> _usersRepo;
        public GameController(IGame game, IRepository<Games> gameRepository, IRepository<Users> usersRepository)
        {
            _game = game;
            _gameRepo = gameRepository;
            _usersRepo = usersRepository;
        }

        [HttpPost]
        public IActionResult Guess([FromForm] GuesLetterViewModel guesLetterViewModel)
        {
            if (guesLetterViewModel is null)
            {
                throw new ArgumentNullException(nameof(guesLetterViewModel));
            }

            if (guesLetterViewModel.Letter.Length > 1)
            {
                return BadRequest($"Letter length is more than 1");
            }
            else
            {
                try
                {
                    //Check for the letter
                    //Return correct or bad guess
                    _game.Guess(guesLetterViewModel.Letter.ToLower());

                    if (_game.Adivina)
                    {
                        GameViewModel loseGame = new GameViewModel();
                        loseGame.Name = _game.Username;
                        loseGame.Tries = _game.Tries;
                        loseGame.Word = _game.Word;
                        loseGame.Attemps = _game.Attempts;
                        loseGame.Win = true;
                        loseGame.Lose = false;
                        return View("Index", loseGame);
                    }

                    if (_game.Tries == 0)
                    {
                        GameViewModel loseGame = new GameViewModel();
                        loseGame.Name = _game.Username;
                        loseGame.Tries = _game.Tries;
                        loseGame.Word = _game.Word;
                        loseGame.Attemps = _game.Attempts;
                        loseGame.Lose = true;
                        loseGame.Win = false;
                        return View("Index", loseGame);
                    }

                    GameViewModel gameViewModel = new GameViewModel();
                    gameViewModel.Name = _game.Username;
                    gameViewModel.Tries = _game.Tries;
                    gameViewModel.Word = _game.Word;
                    gameViewModel.Attemps = _game.Attempts;

                    return View("Index", gameViewModel);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed guessing the letter. Ex: {ex}");
                }
            }
        }

        public ActionResult Index([FromForm] GameViewModel game, string word)
        {
            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            try
            {
                GameViewModel gameViewModel = new GameViewModel();
                gameViewModel.Name = game.Name;
                gameViewModel.Lose = false;
                gameViewModel.Attemps = new List<string>();
                gameViewModel.Tries = 6;
                gameViewModel.Instructions = "El objetivo de este juego es adivinar la palabra secreta que ha pensado " +
                                                "el otro jugador. Debes lograrlo antes de ser 'ahorcado'. Para esto debes seguir las siguientes reglas: " +
                                                "\n1. Puedes adivinar tirando letras al azar. Cada letra erronéa es un intento que se resta." +
                                                "\n2. Tienes 6 oportunidades, una correspondiente a cada parte del muñeco que se va a dibujar " +
                                                "(cabeza, torso, dos brazos, dos piernas). Cuando se terminas los intentos, pierdes." +
                                                "\n3. Puedes saber la cantidad de letras que posee la palabra a adivinar.";
                if (word != null)
                {
                    gameViewModel.Word = word;

                }
                else
                {
                    gameViewModel.Word = PickRandomWord();
                }


                _game.Start(gameViewModel.Name).Config(gameViewModel.Word, gameViewModel.Tries);

                return View(gameViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error when starting the game. Ex: {ex}");
            }
        }

        private string PickRandomWord()
        {
            List<string> randomString = new List<string>()
            {
                "agiles",
                "ingenieria",
                "materia",
                "fisica",
                "metodologias",
                "nintendo",
                "onomatopeya",
                "paralelepipedo",
                "argentina",
                "rosario",
            };

            int randomIndex = RandomNumberGenerator.GetInt32(randomString.Count - 1);

            return randomString[randomIndex];
        }
    }
}