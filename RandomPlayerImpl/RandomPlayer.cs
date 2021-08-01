using System;
using PlayerImpl;
using XOContracts;
using XODTO;
using XOPlayersContracts;
using XOServerContracts;

namespace RandomPlayerImpl
{
    public class RandomPlayer : Player, IRandomPlayer
    {

        public XOCellDTO makeMove(IXOBoard board)
        {
            var retval = new XOCellDTO();
            int row = -1, col = -1;

            if (board.getStatus() == Status.None)
            {
                Random rnd = new Random();
                bool isPutSucceed = false;
                while (isPutSucceed == false)
                {
                    row = rnd.Next(board.Size);
                    col = rnd.Next(board.Size);
                    isPutSucceed = board.Put(Mark, row, col);
                }
            }

            retval.Row = row;
            retval.Col = col;
            return retval;
        }
    }
}