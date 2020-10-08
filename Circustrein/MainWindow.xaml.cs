using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Circustrein
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Train train;

        public MainWindow()
        {
            InitializeComponent();
            train = new Train();
        }

        private void BtnSeeResult_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
