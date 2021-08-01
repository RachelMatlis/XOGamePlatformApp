using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;
using XODTO;

namespace XOPlayersContracts
{
    public interface IPlayer
    {
        public XorO Mark { get; set; }
        XOCellDTO makeMove(IXOBoard board);
    }
}