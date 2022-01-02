
namespace TicaTacToe
{
    internal class WindCondtionObject
    {
        public bool HasWon { get; private set; }
        public bool IsDraw { get; private set; } = false; //set to false at default and passed only if IsDraw() method is called

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
