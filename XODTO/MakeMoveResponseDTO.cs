using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XODTO
{
    public class MakeMoveResponseDTO
    {
        public string Message { get; set; }
        public IXOBoard Board { get; set; } // data of reaction
        //public XOBoardMatDTO Board { get; set; } // data of reaction
        public bool Success { get; set; }
    }
}
