using InfraAttributes;
using System;
using XOContracts;

namespace XOBoardMatImpl
{
    public class XOBoard : IXOBoard
    {
        XorO[,] _board;
        int _size;

        private void initBoard()
        {
            //Initialize board to empty 
            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++)
                {
                    _board[i, j] = XorO.Empty;
                }
        }

        public XOBoard(int size = 3)
        {
            //_board = new XorO[size, size];
            _size = 3;
            _board = new XorO[_size, _size];
            //_size = size;
            initBoard();
        }
        public bool Put(XorO xoro, int row, int col)
        {
            var retval = false;

            try
            {
                if ((0 <= row && row < Size) && (0 <= col && col < Size))
                {
                    if (getCell(row, col) == XorO.Empty)
                    {
                        _board[row, col] = xoro;
                        retval = true;
                    }

                }

            }
            catch
            {
                throw new IndexOutOfRangeException();
            }

            return retval;
        }

        public Status getStatus()
        {
            var retval = Status.None;
            for (var i = 0; i < Size; i++)
            {
                retval = checkRow(i);
                if (retval != Status.None)
                {
                    break;
                }
            }
            if (retval == Status.None)
            {
                for (var i = 0; i < 3; i++)
                {
                    retval = checkCol(i);
                    if (retval != Status.None)
                    {
                        break;
                    }
                }
            }
            if (retval == Status.None)
            {
                retval = checkLRDiag();
            }

            if (retval == Status.None)
            {
                retval = checkRLDiag();
            }

            if (retval == Status.None)
            {
                retval = checkDraw();
            }
            return retval;

        }

        public XorO getCell(int row, int col)
        {
            return _board[row, col];
        }


        public XorO[,] BoardMat
        {
            get
            {
                return _board;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        private Status genCheck(int index, Func<int, int> cellFunc)
        {
            int sum = 0;
            var retval = Status.None;
            for (var i = 0; i < Size; i++)
            {
                sum += cellFunc(i);//cellFunc(index,i);
            }
            if (Math.Abs(sum) == Size)
            {
                retval = sum < 0 ? Status.O : Status.X;
            }
            return retval;
        }
        private Status checkRow(int row)
        {
            var retval = Status.None;
            retval = genCheck(row, (param_col) => (int)_board[row, param_col]);

            return retval;
        }

        private Status checkCol(int col)
        {
            var retval = Status.None;
            retval = genCheck(col, (param_row) => (int)_board[col, param_row]);

            return retval;


        }

        private Status checkRLDiag()
        {
            var retval = Status.None;
            retval = genCheck(0, (i) => (int)_board[i, Size - i - 1]);

            return retval;


        }

        private Status checkLRDiag()
        {
            var retval = Status.None;
            retval = genCheck(0, (i) => (int)_board[i, i]);

            return retval;



        }
        private Status checkDraw()
        {
            var retval = Status.Draw;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (_board[i, j] == XorO.Empty)
                    {
                        retval = Status.None;
                        break;
                    }
                }
            }
            return retval;
        }

    }
}