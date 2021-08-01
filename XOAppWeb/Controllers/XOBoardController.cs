using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOContracts;
using XODTO;
using XOServerContracts;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class XOBoardController : ControllerBase
    {
        IXOBoardService _boardService;
        public XOBoardController(IXOBoardService boardService)
        {
            _boardService = boardService; 
        }
        // GET: api/<XOBoardController>
        [HttpGet]
        public IEnumerable<string> GetBoard()
        {
            return new string[] { "value1", "value2" };
        }

        
        // POST api/<XOBoardController>
        [HttpPost]
        public XOCellResponseDTO UpdateBoard([FromBody] XOCellDTO cell)
        {
            var retval = new XOCellResponseDTO();
            //// XorO xoro = Enum.Parse<XorO>(cell.XorO);
            //retval.Board = _board as XOBoard;
            //retval.Succeed = _board.Put(cell.XorO, cell.Row, cell.Col);
            //return retval;
            //var retval = _boardService.PutOnBoard(cell.XorO, cell.Row, cell.Col);
            return retval;

        }

    }
}
