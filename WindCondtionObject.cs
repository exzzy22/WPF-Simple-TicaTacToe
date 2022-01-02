using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal class WindCondtionObject
    {
        public bool HasWon { get; private set; }
        public bool IsDraw { get; private set; } = false;

        public WindCondtionObject(bool hasWon)
        { 
            HasWon = hasWon;
        }

        public WindCondtionObject(bool hasWon, bool isDraw)
        {
            HasWon = hasWon;
            IsDraw = isDraw;
        }
    }
}
