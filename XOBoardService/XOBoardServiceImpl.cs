using System;
using XOContracts;
using XODTO;
using XOServerContracts;

namespace XOBoardService
{
    public class XOBoardServiceImpl : IXOBoardService
    {

        //public XOCellResponseDTO PutOnBoard(XorO xoro, int row, int col)
        //{
        //    var retval = new XOCellResponseDTO();
        //    retval.PostmanMoveSucceed = _board.Put(xoro, row, col);
        //    retval.Board = new XOBoardMatDTO();
        //    retval.Board.BoardMat = new XorO[_board.Size][];

        //    for (var i = 0; i < _board.Size; i++)
        //    {
        //        retval.Board.BoardMat[i] = new XorO[_board.Size];
        //        for (var j = 0; j < _board.Size; j++)
        //        {
        //            retval.Board.BoardMat[i][j] = _board.getCell(i, j);
        //        }

        //    }

        //    return retval;

        //}
        public XOBoardMatDTO MakeResponse(IXOBoard board)
        {
            var retval = new XOBoardMatDTO();
            retval.BoardMat = null;

            if (board != null)
            {
                retval.BoardMat = new XorO[board.Size][];

                for (var i = 0; i < board.Size; i++)
                {
                    retval.BoardMat[i] = new XorO[board.Size];
                    for (var j = 0; j < board.Size; j++)
                    {
                        retval.BoardMat[i][j] = board.getCell(i, j);
                    }

                }

            }
           
            return retval;
        }
    }
}
