using System;
using XOContracts;
using XODTO;
using XOPlayersContracts;
using XOServerContracts;

namespace PlayersImpl
{
    public class PlayersService: IPlayersService
    {
        IGameService _gameService;
        IXOBoardService _boardService;
        public PlayersService(IGameService gameService, IXOBoardService boardService)
        {
            _gameService = gameService;
            _boardService = boardService;
        }

        public MoveResponseDTO playerMove(IPlayer player, MoveDTO move)
        {
            var makeMoveResponse = new MakeMoveResponseDTO();
            makeMoveResponse = _gameService.MakeMove(move);

            if (makeMoveResponse.Success)
            {
                player.Mark = XorO.O;
                player.makeMove(makeMoveResponse.Board);
            }

            var retval = new MoveResponseDTO();
            retval.Message = makeMoveResponse.Message;
            retval.Success = makeMoveResponse.Success;
            retval.BoardMat = _boardService.MakeResponse(makeMoveResponse.Board).BoardMat;

            return retval;
        }
    }
}
