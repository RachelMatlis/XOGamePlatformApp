using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XODTO
{
    public class MoveDTO
    {
        public int GameToken { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public XorO XorO = XorO.X;

    }
}
