using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        }

        private void BtnSeeResult_Click(object sender, RoutedEventArgs e)
        {
            train = new Train(GatherAnimals());
            ShowResults();
        }

        private List<Animal> GatherAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (TextBox tbx in FindVisualChildren<TextBox>(dpAnimalInput))
            {
                string[] arrTbxTag = tbx.Tag.ToString().Split('_');
                string strSize = arrTbxTag[0];
                string strType = arrTbxTag[1];

                Sizes size = strSize == Sizes.kleine.ToString() ? Sizes.kleine :
                             strSize == Sizes.middelgrote.ToString() ? Sizes.middelgrote : Sizes.grote;
                Types type = strType == Types.planteter.ToString() ? Types.planteter : Types.vleeseter;

                try
                {
                    for (int i = 0; i < Convert.ToInt32(tbx.Text); i++)
                        animals.Add(new Animal(size, type));
                }
                catch (Exception)
                {
                    // do nothing
                }
            }
            return animals;
        }

        /// <summary>
        /// Return all controls named T inside depObj
        /// </summary>
        /// <typeparam name="T">Wanted control</typeparam>
        /// <param name="depObj">Object in which the wanted controls are</param>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                        yield return t;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void ShowResults()
        {
            LblAmountAnimals.Content = train.AnimalCount;
            LblAmountWagons.Content = train.GetTrainWagons().Count;
            LblTotalSpaceUsage.Content = train.ToString();
            LvWagons.ItemsSource = train.GetTrainWagons();
        }

        private void LvWagons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Wagon selectedWagon = (Wagon)LvWagons.SelectedItem;
            if (selectedWagon != null)
            {
                LblAmountAnimalsInWagon.Content = selectedWagon.AmountAnimals;
                LblUsedSpace.Content = selectedWagon.Efficiency;
                LvAnimalsInWagon.ItemsSource = selectedWagon.GetAnimalsInWagon();
            }
        }
    }
}
