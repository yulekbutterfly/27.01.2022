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

namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientProductWindow.xaml
    /// </summary>
    public partial class ClientProductWindow : Window
    {
        public ClientProductWindow()
        {
            InitializeComponent();
            lvClientProduct.ItemsSource = ClassHelper.AppData.Context.ClientProduct.ToList();
        }

        private void btn_registr_Click(object sender, RoutedEventArgs e)
        {
            Arenda arendaWindow = new Arenda();
            this.Hide();
            arendaWindow.ShowDialog();
            this.Show();
        }
    }
}
