using System;

namespace TicaTacToe
{
    internal static class StringParser
    {
        public static Point ParseAString(string btnText) //Gets array location from button name which is in string format: ButtonXY and turn that to a Point
        {
            var text = btnText.Substring(6, 2);
            var x = (int)Char.GetNumericValue(text[0]);
            var y = (int)Char.GetNumericValue(text[1]);
            Point point = new Point(x, y);
            return point;
        }
    }
}
