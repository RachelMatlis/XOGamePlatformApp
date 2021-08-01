using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOContracts;

namespace XODTO
{
    public class XOCellDTO
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public XorO XorO { get; set; }
    }
}
