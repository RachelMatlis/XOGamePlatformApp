using System;
using System.Collections.Generic;
using System.Text;
using XODTO;
using XOPlayersContracts;

namespace XOServerContracts
{
    public interface IPlayersService
    {
        public MoveResponseDTO playerMove(IPlayer player, MoveDTO move);
    }
}
