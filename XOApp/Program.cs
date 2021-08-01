using FactoryImpl;
using System;
using System.Reflection;
using XOContracts;
using XOPlayersContracts;

namespace XOApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            
            var factory = Factory.getInstance();
            IXOBoard board = factory.Create<IXOBoard>(3);
            var playerType = factory.GetAll<IPlayer>();
            factory.Create<IPlayer>(playerType[0]);

            // IXOBoard board = factory.makeBoard(3);//new XOBoard(3);
            IXOBoardView boardView = factory.Create<IXOBoardView>();//new XOBoardView();
            // IXOBoardView boardView = factory.makeBoardView();//new XOBoardView();
            boardView.Display(board);
            board.Put(XorO.X, 0, 0);
            boardView.Display(board);
            board.Put(XorO.O, 1, 1);
            boardView.Display(board);

        }
    }
}
