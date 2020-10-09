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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSeeResult_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> circusAnimals = GatherAnimals();
            Train train = new Train();
            train.MakeTrainReady(circusAnimals);
        }

        private List<Animal> GatherAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (TextBox tbx in FindVisualChildren<TextBox>(dpAnimalInput))
            {
                if (tbx.Text != "0")
                {
                    string[] arrTbxTag = tbx.Tag.ToString().Split('_');
                    Sizes size = arrTbxTag[0] == Sizes.kleine.ToString() ? Sizes.kleine :
                                    arrTbxTag[0] == Sizes.middelgrote.ToString() ? Sizes.middelgrote : Sizes.grote;
                    Types type = arrTbxTag[1] == Types.planteter.ToString() ? Types.planteter : Types.vleeseter;
                    int weight = Convert.ToInt32(size);

                    for (int i = 0; i < Convert.ToInt32(tbx.Text); i++)
                        animals.Add(new Animal(size, type, weight));
                }
            }
            return animals;
        }

        /// <summary>
        /// Return all controls named T inside depObj
        /// </summary>
        /// <typeparam name="T">Name of the wanted control</typeparam>
        /// <param name="depObj">Name of the object in which the wanted controls are</param>
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
    }
}
