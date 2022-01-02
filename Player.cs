using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal class Player
    {
        public string Symbol { get; private set; }
        public string WiningMessage { get; private set; }

        public int WinCounter { get; private set; }

        public Player(string symbol)
        {
            Symbol = symbol;
            WiningMessage = @"{symbol} has won!";
            WinCounter = 0;
        }

        public string HasWon()
        {
            return WiningMessage;
        }

        public void WinIncrement()
        { 
            WinCounter++;
        }
    }
}
