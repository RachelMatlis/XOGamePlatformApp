using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XODTO;
using XOServerContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase // Create game
    {
        IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;

        }

        // POST api/<GameController>
        [HttpPost]
        public CreateGameResponseDTO Post([FromBody] GameDTO game)
        {
            var retval = _gameService.CreateGame(game);
            return retval;
        }

    }
}
