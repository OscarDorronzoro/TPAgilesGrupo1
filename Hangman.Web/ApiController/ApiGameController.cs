using Hangman.Data.Interfaces;
using Hangman.Data.Models;
using Hangman.infrastructure.Repository;
using Hangman.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Web.Controllers
{
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly IGame _game;
        private readonly IRepository<Games> _gameRepo;
        private readonly IRepository<Users> _usersRepo;
        public ApiGameController(IGame game, IRepository<Games> gameRepository, IRepository<Users> usersRepository)
        {
            _game = game;
            _gameRepo = gameRepository;
            _usersRepo = usersRepository;
        }

        [HttpPost]
        [Route("api/start")]
        public async Task<IActionResult> StartGame([FromBody] GameViewModel gameViewModel)
        {
            if (gameViewModel is null)
            {
                throw new ArgumentNullException(nameof(gameViewModel));
            }
            try
            {
                _game.Start(gameViewModel.Name).Config(gameViewModel.Word, gameViewModel.Tries);

                var usersTemp = (IEnumerable<Users>)await _usersRepo.GetAllAsync();
                var userTemp = usersTemp.Where(x => x.Username == gameViewModel.Name).FirstOrDefault();

                var actualGame = new Games()
                {
                    User = userTemp,
                    Word = gameViewModel.Word
                };

                await _gameRepo.InsertAsync(actualGame);

                return Ok(actualGame);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error when starting the game. Ex: {ex}");
            }
        }

        [HttpPost]
        [Route("api/guess")]
        public async Task<IActionResult> GuessLeter([FromBody] GuesLetterViewModel guesLetterViewModel)
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
                    var actualGame = await _gameRepo.GetByIdAsync(guesLetterViewModel.GameId);

                    //Check for the letter
                    //Return correct or bad guess
                    _game.Guess(guesLetterViewModel.Letter);

                    return Ok(_game.Word);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed guessing the letter. Ex: {ex}");
                }
            }
        }

    }
}
