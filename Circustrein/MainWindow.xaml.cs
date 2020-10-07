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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSeeResult_Click(object sender, RoutedEventArgs e)
        {
            CircusDieren circusDieren = new CircusDieren();
            circusDieren.VerzamelDieren(spPlantEters, spVleesEters);
        }
    }
}
