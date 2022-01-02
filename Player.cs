
namespace TicaTacToe
{
    internal class Player
    {
        public string Symbol { get; private set; }
        public string WiningMessage { get; private set; } //shows at new window on win
        public int WinCounter { get; private set; }
        public int ArrayValue { get; private set; } //value placed in array for checking wind condition, 1 for P1(win condition sum of 3 in row/column) and -1 for P2(win condition sum of -3 in row/column)
        public byte[] PlayerColor { get; private set; } //used for setting foreground color every time changing between 'X' and 'O'

        public Player(string symbol,byte[] color, int arrayValue)
        {
            Symbol = symbol;
            WiningMessage = $"{symbol} has won!";
            PlayerColor = color;
            ArrayValue = arrayValue;
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
        public void WinReset()
        {
            WinCounter=0;
        }
    }
}
