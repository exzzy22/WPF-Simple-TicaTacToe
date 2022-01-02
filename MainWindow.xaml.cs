using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            if (sender as Button != RestartButton && sender as Button != ExitButton)
            {
                var btn = sender as Button;
                var btnName = btn.Name;
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
                    BoardLogic.ClearBoard();
                }

                else if (BoardLogic.CheckWin().HasWon)
                {
                    BoardLogic.CurrnetPlayer.WinIncrement();
                    WinnerTextWindow winnerWindow = new WinnerTextWindow(BoardLogic.CurrnetPlayer.WiningMessage);
                    winnerWindow.Owner = this;
                    winnerWindow.ShowDialog();
                    ResetButtonContent();
                    BoardLogic.ClearBoard();
                    if (BoardLogic.PlayerOne.WinCounter > 0 || BoardLogic.PlayerTwo.WinCounter > 0)
                    {
                        PlayerOneWins.Text = BoardLogic.PlayerOne.WinCounter.ToString();
                        PlayerTwoWins.Text = BoardLogic.PlayerTwo.WinCounter.ToString();
                    }
                }
                else BoardLogic.ChangePlayer();
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

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonContent();
            BoardLogic.ResetCounter();
            PlayerOneWins.Text = "";
            PlayerTwoWins.Text = "";
            BoardLogic.ClearBoard();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
