using Checkers;
using CheckersGame.Model;
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
using System.Windows.Shapes;

namespace CheckersGame.View
{
    /// <summary>
    /// Interaction logic for Modes.xaml
    /// </summary>
    public partial class Modes : Window
    {
        public Modes()
        {
            InitializeComponent();
        }

        private void Mode2_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Owner = this;
            playWindow.Show();
            
        }

        private void Mode1_Click(object sender, RoutedEventArgs e)
        {

            PlayWindow playWindow = new PlayWindow();
            playWindow.Owner = this;
            playWindow.Show();
        }
    }
}
