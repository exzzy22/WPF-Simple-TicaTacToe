using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TicaTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardLogic BoardLogic = new BoardLogic();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayerClicks(object sender, RoutedEventArgs e)
        {
            if (sender as Button != RestartButton && sender as Button != ExitButton) //since all buttons trigger this event checks for Restart and Exit button and skip this code for them
            {
                var btn = sender as Button;
                var btnName = btn.Name;
                btn.IsEnabled = false;
                var playerColor = BoardLogic.CurrnetPlayer.PlayerColor;
                btn.Foreground = new SolidColorBrush(Color.FromRgb(playerColor[0], playerColor[1], playerColor[2]));
                btn.Content = BoardLogic.CurrnetPlayer.Symbol;
                BoardLogic.BoardSet(StringParser.ParseAString(btnName));

                if (BoardLogic.CheckWin().IsDraw)
                {
                    WinnerTextWindow winnerWindow = new WinnerTextWindow("Draw");
                    winnerWindow.Owner = this;
                    winnerWindow.ShowDialog();
                    ResetButtonContent();
                    EnableButons();
                    BoardLogic.ClearBoard();
                    TurnText();
                }

                else if (BoardLogic.CheckWin().HasWon)
                {
                    BoardLogic.CurrnetPlayer.WinIncrement();
                    WinnerTextWindow winnerWindow = new WinnerTextWindow(BoardLogic.CurrnetPlayer.WiningMessage);
                    winnerWindow.Owner = this;
                    winnerWindow.ShowDialog();
                    ResetButtonContent();
                    EnableButons();
                    BoardLogic.ClearBoard();
                    if (BoardLogic.PlayerOne.WinCounter > 0 || BoardLogic.PlayerTwo.WinCounter > 0)
                    {
                        PlayerOneWins.Text = BoardLogic.PlayerOne.WinCounter.ToString();
                        PlayerTwoWins.Text = BoardLogic.PlayerTwo.WinCounter.ToString();
                    }
                    TurnText();
                }
                else BoardLogic.ChangePlayer();
                Turn.Text = $"{BoardLogic.CurrnetPlayer.Symbol} turn";
            }
        }
        public void ResetButtonContent()
        {
            Button00.Content = "";
            Button01.Content = "";
            Button02.Content = "";
            Button10.Content = "";
            Button11.Content = "";
            Button12.Content = "";
            Button20.Content = "";
            Button21.Content = "";
            Button22.Content = "";
        }

        public void EnableButons()
        {
            Button00.IsEnabled = true;
            Button01.IsEnabled = true;
            Button02.IsEnabled = true;
            Button10.IsEnabled = true;
            Button11.IsEnabled = true;
            Button12.IsEnabled = true;
            Button20.IsEnabled = true;
            Button21.IsEnabled = true;
            Button22.IsEnabled = true;
        }
        private void TurnText()
        {
            if (BoardLogic.RoundCounter % 2 == 0) Turn.Text = "O turn";
            else Turn.Text = "X turn";
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonContent();
            EnableButons();
            BoardLogic.ResetCounter();
            PlayerOneWins.Text = "";
            PlayerTwoWins.Text = "";
            BoardLogic.ClearBoard();
            TurnText();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //enables form drag anywhere on windows
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
