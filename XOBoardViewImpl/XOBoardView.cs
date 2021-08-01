using InfraAttributes;
using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XOBoardViewImpl
{
    [Register(typeof(IXOBoardView))]
    class XOBoardView:IXOBoardView
    {
        public void Display(IXOBoard board)
        {
            for (var i = 0; i < board.Size; i++)
            {
                for (var j = 0; j < board.Size; j++)
                {
                    Console.Write(board.getCell(i, j));
                }
                Console.WriteLine(); 

            }
        }
    }
}
