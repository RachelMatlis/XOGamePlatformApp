using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;
using XODTO;

namespace XOServerContracts
{
    public interface IXOBoardService
    {
        //public XOCellResponseDTO PutOnBoard(XorO xoro, int Row, int Col);
        public XOBoardMatDTO MakeResponse(IXOBoard board);
    }
}
