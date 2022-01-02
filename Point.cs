using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal class Point
    {
        public int _row { get; private set; }
        public int _col { get; private set; }

        public Point(int row, int col)
        {
            row = _row;
            col = _col;
        }
    }
}
