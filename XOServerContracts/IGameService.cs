using System;
using System.Collections.Generic;
using System.Text;
using XODTO;

namespace XOServerContracts
{
    public interface IGameService
    {
        public CreateGameResponseDTO CreateGame(GameDTO user);
        public MakeMoveResponseDTO MakeMove(MoveDTO move);
    }
}
