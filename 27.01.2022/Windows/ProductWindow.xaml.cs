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
using _27._01._2022.Windows;



namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        List<string> ListSort = new List<string>()
            {
                "По умолчанию", "По наименованию продукта", "По типу", "По цене","По гарантии","По дате истечения"
            };

        public ProductWindow()
        {
            InitializeComponent();
            lvProduct.ItemsSource = ClassHelper.AppData.Context.Product.ToList();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;
        }

        private void Filter()
        {
            List<EF.Product> listProduct = new List<EF.Product>();
            listProduct = ClassHelper.AppData.Context.Product.ToList();
            listProduct = listProduct.Where(i => i.IsDeleted == false).ToList();

            //издевательства (Поиск по нужным параметрам и соритровка по нужным параметрам)
            listProduct = listProduct.Where(i =>
            i.NameProduct.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Warranty.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Price.ToString().ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Type.NameType.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.DateOfIssue.ToString().Contains(txtSearch.Text.ToLower())).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                     listProduct =  listProduct.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                     listProduct =  listProduct.OrderBy(i => i.NameProduct).ToList();
                    break;
                case 2:
                    listProduct = listProduct.OrderBy(i => i.IDType).ToList();
                    break;
                case 3:

                case 4:
                     listProduct =  listProduct.OrderBy(i => i.Price).ToList();
                    break;
                
                case 5:
                     listProduct =  listProduct.OrderBy(i => i.Warranty).ToList();
                    break;

                case 6:
                     listProduct =  listProduct.OrderBy(i => i.DateOfIssue).ToList();
                    break;
                default:
                    listProduct = listProduct.OrderBy(i => i.ID).ToList();
                    break;


            }

            lvProduct.ItemsSource =  listProduct;
        }

        private void btnaddProd_Click(object sender, RoutedEventArgs e)
        {


            AddingHardware addingHardware = new AddingHardware();
            this.Hide();
            addingHardware.ShowDialog();
            this.ShowDialog();
            //lvClient.ItemsSource = ClassHelper.AppData.Context.Client.ToList();



        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void lvProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvProduct.SelectedItem is EF.Product)
            {
                var empl = lvProduct.SelectedItem as EF.Product;
                this.Hide();
                AddingHardware addingHardware = new AddingHardware(empl);
                addingHardware.ShowDialog();
                this.ShowDialog();

                Filter();
            }
        }
    }
}
