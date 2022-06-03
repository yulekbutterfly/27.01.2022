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
using static _27._01._2022.ClassHelper.DataTransmission;

namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChooseProduct.xaml
    /// </summary>
    public partial class ChooseProduct : Window
    {
        public ChooseProduct()
        {
            InitializeComponent();
            lvProduct.ItemsSource = ClassHelper.AppData.Context.Product.ToList();

        }

        private void lvProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                GetProduct = lvProduct.SelectedItem as EF.Product;
                this.Close();
                this.Hide();
        }



    }
}
