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
            var x = Convert.ToInt32(text.Substring(0, 1));
            var y = Convert.ToInt32(text.Substring(1, 1));

            return new Point(x, y);
        }
    }
}
