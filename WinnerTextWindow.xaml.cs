﻿using System;
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
using System.Windows.Shapes;

namespace TicaTacToe
{
    /// <summary>
    /// Interaction logic for WinnerTextWindow.xaml
    /// </summary>
    public partial class WinnerTextWindow : Window
    {

        public WinnerTextWindow(string winnerOrDraw)
        {
            InitializeComponent();
            winnerButton.Content = winnerOrDraw;
        }

        private void winnerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
