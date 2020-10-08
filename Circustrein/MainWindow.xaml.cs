﻿using System;
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
        private List<Animal> circusAnimals;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSeeResult_Click(object sender, RoutedEventArgs e)
        {
            GatherAnimals();

        }

        private void GatherAnimals()
        {
            circusAnimals = new List<Animal>();
            foreach (TextBox tbx in FindVisualChildren<TextBox>(dpAnimalInput))
            {
                if (tbx.Text != "0")
                {
                    string[] arrTbxTag = tbx.Tag.ToString().Split('_');
                    Sizes size;
                    Types type = arrTbxTag[1] == Types.planteter.ToString() ? Types.planteter : Types.vleeseter;
                    int weight;

                    if (arrTbxTag[0] == Sizes.kleine.ToString())
                    {
                        size = Sizes.kleine;
                        weight = Convert.ToInt32(Sizes.kleine);
                    }
                    else if (arrTbxTag[0] == Sizes.middelgrote.ToString())
                    {
                        size = Sizes.middelgrote;
                        weight = Convert.ToInt32(Sizes.middelgrote);
                    }
                    else
                    {
                        size = Sizes.grote;
                        weight = Convert.ToInt32(Sizes.grote);
                    }

                    for (int i = 0; i < Convert.ToInt32(tbx.Text); i++)
                    {
                        circusAnimals.Add(new Animal(size, type, weight));
                    }
                }
            }
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
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
