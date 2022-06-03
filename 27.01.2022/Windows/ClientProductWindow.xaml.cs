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
    /// Логика взаимодействия для ClientProductWindow.xaml
    /// </summary>
    public partial class ClientProductWindow : Window
    {
        public ClientProductWindow()
        {
            InitializeComponent();
            lvClientProduct.ItemsSource = ClassHelper.AppData.Context.ClientProduct.Where(i=>i.Product.IDStatus != 4).ToList();
        }

        private void btn_registr_Click(object sender, RoutedEventArgs e)
        {
            Arenda arendaWindow = new Arenda();
            lvClientProduct.ItemsSource = ClassHelper.AppData.Context.ClientProduct.ToList();
            this.Hide();
            arendaWindow.ShowDialog();
            this.ShowDialog();

        }

        private void lvClientProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvClientProduct.SelectedItem is EF.ClientProduct)
            {
                btnBack.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (lvClientProduct.SelectedItem is EF.ClientProduct)
            {

                var rent= lvClientProduct.SelectedItem as EF.ClientProduct;
                BackWindow backWindow = new BackWindow(rent);
                backWindow.ShowDialog();
            }
        }

        
    }
}
