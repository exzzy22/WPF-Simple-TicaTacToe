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

        public Player PlayerOne = new Player("X");
        public Player PlayerTwo = new Player("O");

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
    }
}
