using Gamebox.Server.DTO;
using Gamebox.Server.Models;
using Gamebox.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gamebox.Server.Controllers
{
    [ApiController]
    [EnableCors("Policy")]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gamesService;

        public GamesController(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<ActionResult<Game>> GetGameById(string id)
        {
            var game = await _gamesService.GetGameById(id);

            if (game is null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost()]
        public ActionResult<Rating> CreateGame([FromBody] GameDTO game)
        {
            try
            {
                _gamesService.CreateGame(game);
            }
            catch (Exception ex)
            {
                return BadRequest("Error creating game: " + ex);
            }
            return Ok();

        }

    }
}
