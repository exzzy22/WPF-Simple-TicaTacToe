using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal class BoardLogic
    {
        public Player CurrnetPlayer { get; private set; }
        private int[,] _board { get; set; }

        public Player PlayerOne = new Player("X",1);
        public Player PlayerTwo = new Player("O",-1);

        public BoardLogic()
        {
            CurrnetPlayer = PlayerOne;
            _board = new int[3,3] { {0,0,0 },{0,0,0 },{0,0,0 } };
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
        public Player Winner(int sum)
        {
            if (sum == 3) return PlayerOne;
            else return PlayerTwo;
        }
        public bool DoWeHaveWinner(int sum)
        {
            if (sum == 3) return true;
            else if (sum == -3) return true;
            else return false;
        }

        public int WinningSum()
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += _board[i, j];
                    if (sum == 3 || sum == -3) return sum;
                }
                sum = 0;
            }
            return sum;
        }
    }
}
