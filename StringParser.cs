using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicaTacToe
{
    internal static class StringParser
    {
        public static Point ParseAString(string btnText)
        {
            var text = btnText.Substring(6, 2);
            var x = (int)Char.GetNumericValue(text[0]);
            var y = (int)Char.GetNumericValue(text[1]);
            Point point = new Point(x, y);
            return point;
        }
    }
}
