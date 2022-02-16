using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pong
{
    /// <summary>
    /// Interakční logika pro Lose.xaml
    /// </summary>
    public partial class Lose : Window
    {
        public Lose()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
           Close();
        }
    }
}
