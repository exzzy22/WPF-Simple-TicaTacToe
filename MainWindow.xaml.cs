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
        BoardLogic boardLogic = new BoardLogic();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayerClicks(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var btnName = btn.Name;
            btn.Content = boardLogic.CurrnetPlayer.Symbol;
            boardLogic.ChangePlayer();
        }

        private Point Parser(string btnText)
        {
            var text = btnText.Substring(6, 2);
            var x = Convert.ToInt32(text.Substring(0, 1));
            var y = Convert.ToInt32(text.Substring(1, 1));

            return new Point(x, y);
        }
    }
}
