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
using _27._01._2022.ClassHelper;

namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для BackWindow.xaml
    /// </summary>
    public partial class BackWindow : Window
    {
        EF.ClientProduct globalRent;
        public BackWindow(EF.ClientProduct rent)
        {
            InitializeComponent();
            tbClient.Text = rent.Client.Lname;
            tbEmployee.Text = rent.Employee.Lname;
            tbProduct.Text = rent.Product.NameProduct;
            tbDateOfSell.Text = rent.SaleStartDate.ToString();
            
            globalRent=rent;
            
            
        }

        private void dpReturnDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbCost.Text = Calculations.CostOfRent(Convert.ToDateTime(globalRent.SaleStartDate), Convert.ToDateTime(dpReturnDate.SelectedDate), globalRent.Product.Price).ToString();
        }

        private void btnBackRent_Click(object sender, RoutedEventArgs e)
        {
            globalRent.TotalCost =Convert.ToDecimal(tbCost.Text);
            globalRent.Product.IDStatus = 4;
            ClassHelper.AppData.Context.SaveChanges();
        }
    }
}
