using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XODTO
{
    public class MoveResponseDTO
    {
        public string Message { get; set; }
        public XorO[][] BoardMat { get; set; }
        public bool Success { get; set; }
    }
}
