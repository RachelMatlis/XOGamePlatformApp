using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOAppWeb.Controllers;
using XOBoardMatImpl;
using XOContracts;
using XODTO;
using XOPlayersContracts;
using XOServerContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomPlayerGameController : ControllerBase
    {
        IRandomPlayer _rndPlayer;
        IPlayersService _playersService;

        public RandomPlayerGameController(IRandomPlayer rndPlayer, IPlayersService players)
        {
            _rndPlayer = rndPlayer;
            _playersService = players;
        }

        // POST api/<RandomPlayerGameController>
        [HttpPost]
        public MoveResponseDTO Post([FromBody] MoveDTO move)
        {
            var retval = new MoveResponseDTO();
            retval = _playersService.playerMove(_rndPlayer, move);
            return retval;
        }

    }
}