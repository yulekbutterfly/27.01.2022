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



namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
            lvProduct.ItemsSource = ClassHelper.AppData.Context.Product.ToList();
        }

        private void btnaddProd_Click(object sender, RoutedEventArgs e)
        {


                AddingHardware addingHardware = new AddingHardware();
                this.Hide();
                addingHardware.Show();
                //lvClient.ItemsSource = ClassHelper.AppData.Context.Client.ToList();


            
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
