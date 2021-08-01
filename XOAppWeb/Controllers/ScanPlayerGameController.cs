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
    public class ScanPlayerGameController : ControllerBase
    {
        IScanPlayer _scanPlayer;
        IPlayersService _playersService;
        public ScanPlayerGameController(IScanPlayer scanPlayer, IPlayersService players)
        {
            _scanPlayer = scanPlayer;
            _playersService = players;
        }


        // POST api/<ScanPlayerGameController>
        [HttpPost]
        public MoveResponseDTO Post([FromBody] MoveDTO move)
        {
            var retval = new MoveResponseDTO();
            retval = _playersService.playerMove(_scanPlayer, move);
            return retval;
        }
    }
}