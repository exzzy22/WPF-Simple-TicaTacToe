using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal class BoardLogic
    {
        public Player CurrnetPlayer { get; private set; }
        private int[,] _board { get; set; }

        public Player PlayerOne = new Player("X", new byte[]{204, 0, 204},1);
        public Player PlayerTwo = new Player("O", new byte[]{ 255, 255, 0 },-1);

        public BoardLogic()
        {
            CurrnetPlayer = PlayerOne;
            _board = new int[,] {{0,0,0},{0,0,0},{0,0,0 }};
        }
        public void ChangePlayer()
        { 
            if (CurrnetPlayer==PlayerOne)CurrnetPlayer = PlayerTwo;
            else
                CurrnetPlayer= PlayerOne;    
        }
        public void BoardSet(Point point)
        {
            _board[point._row, point._col] = CurrnetPlayer.ArrayValue;
        }
        public void ClearBoard()
        {
            CurrnetPlayer = PlayerOne;
            _board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }
        public void ResetCounter()
        {
            PlayerOne.WinReset();
            PlayerTwo.WinReset();
        }
        public WindCondtionObject CheckWin()
        {
            int sum =0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum +=_board[i, j];
                    if (sum == 3 || sum == -3) return new WindCondtionObject(true);
                }
                sum = 0;
            }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += _board[j, i];
                    if (sum == 3 || sum == -3) return new WindCondtionObject(true);
                }
                sum = 0;
            }
            if (_board[1, 1] != 0)
            {
                if (_board[0, 0] + _board[1, 1] + _board[2, 2] == 3 || _board[0, 0] + _board[1, 1] + _board[2, 2] == -3) return new WindCondtionObject(true);
                if (_board[0, 2] + _board[1, 1] + _board[2, 0] == 3 || _board[0, 2] + _board[1, 1] + _board[2, 0] == -3) return new WindCondtionObject(true);
            }
            if(IsDraw())return new WindCondtionObject(true,true);
            return new WindCondtionObject(false);
        }

        private bool IsDraw()
        {
            foreach (var item in _board)
            {
                if (item == 0) return false;
            }
            return true;
        }
    }
}
