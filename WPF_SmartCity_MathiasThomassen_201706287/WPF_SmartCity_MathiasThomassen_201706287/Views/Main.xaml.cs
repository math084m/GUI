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
using WPF_SmartCity_MathiasThomassen_201706287.Models;

namespace WPF_SmartCity_MathiasThomassen_201706287.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewTrees.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListViewTrees.Items.Refresh();
        }
    }
}
