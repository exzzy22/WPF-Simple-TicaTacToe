
namespace TicaTacToe
{
    internal class Point //used to return coordinates for array from StringParser class
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
