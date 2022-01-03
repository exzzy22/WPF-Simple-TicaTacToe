
namespace TicaTacToe
{
    internal class BoardLogic
    {
        public Player CurrnetPlayer { get; private set; } // current player that plays game
        private int[,] _board { get; set; } // used for calculating win condition only

        public int RoundCounter { get; private set; } // odd P1 turn, even P2 turn

        public Player PlayerOne = new Player("X", new byte[]{204, 0, 204},1);
        public Player PlayerTwo = new Player("O", new byte[]{ 255, 255, 0 },-1);

        public BoardLogic()
        {
            CurrnetPlayer = PlayerOne;
            _board = new int[,] {{0,0,0},{0,0,0},{0,0,0 }};
            RoundCounter = 1;
        }
        public void ChangePlayer() //switches players
        { 
            if (CurrnetPlayer==PlayerOne)CurrnetPlayer = PlayerTwo;
            else
                CurrnetPlayer= PlayerOne;    
        }
        public void BoardSet(Point point) //sets value in array at coordinates which player clicked in GUI P1=1 P2=-1
        {
            _board[point.Row, point.Col] = CurrnetPlayer.ArrayValue;
        }
        public void ClearBoard() // reset array value and setting P1 at turn GUI clear is done in main window // called after win condition reached (P1 win/P2 win/draw)
        {
            ++RoundCounter;
            _board = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            if (RoundCounter % 2 == 0) CurrnetPlayer = PlayerTwo;
            else CurrnetPlayer = PlayerOne;
        }
        public void ResetCounter()
        {
            PlayerOne.WinReset();
            PlayerTwo.WinReset();
        }
        public WindCondtionObject CheckWin() // check rows, columns and then diagonals for 3 or -3 value
        {
            int sum =0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum +=_board[i, j];
                    if (sum == 3 || sum == -3) return new WindCondtionObject(true);
                }
                sum = 0;
            }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += _board[j, i];
                    if (sum == 3 || sum == -3) return new WindCondtionObject(true);
                }
                sum = 0;
            }
            if (_board[1, 1] != 0)
            {
                if (_board[0, 0] + _board[1, 1] + _board[2, 2] == 3 || _board[0, 0] + _board[1, 1] + _board[2, 2] == -3) return new WindCondtionObject(true);
                if (_board[0, 2] + _board[1, 1] + _board[2, 0] == 3 || _board[0, 2] + _board[1, 1] + _board[2, 0] == -3) return new WindCondtionObject(true);
            }
            if(IsDraw())return new WindCondtionObject(true,true);
            return new WindCondtionObject(false);
        }

        private bool IsDraw() // if there is no winner and array does not contain 0 value anymore returns true
        {
            foreach (var item in _board)
            {
                if (item == 0) return false;
            }
            return true;
        }
    }
}
