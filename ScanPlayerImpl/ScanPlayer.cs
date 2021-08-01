using System;
using PlayerImpl;
using XOContracts;
using XODTO;
using XOPlayersContracts;

namespace ScanPlayerImpl
{
    public class ScanPlayer : Player, IScanPlayer
    {
        public XOCellDTO makeMove(IXOBoard board)
        {
            var retval = new XOCellDTO();
            retval.Row = -1;
            retval.Col = -1;

            for (var row = 0; row < board.Size; row++)
            {
                for (var col = 0; col < board.Size; col++)
                {
                    if (board.getCell(row, col) == XorO.Empty)
                    {
                        board.Put(Mark, row, col);
                        retval.Row = row;
                        retval.Col = col;
                        break;
                    }
                }

                if (retval.Row != -1)
                    break;
            }

            return retval;
        }
    }
}