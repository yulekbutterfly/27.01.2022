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
using _27._01._2022.EF;
using  _27._01._2022.ClassHelper;
using _27._01._2022.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static _27._01._2022.ClassHelper.DataTransmission;


namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для Arenda.xaml
    /// </summary>


    public partial class Arenda : Window
    {
        private bool isEdit;
        ClientProduct editSale = new ClientProduct();
         EF.ClientProduct globalRent;

        public Arenda()
        {
            InitializeComponent();
            

            isEdit = false;

        }
     
        public Arenda(ClientProduct ClientProduct)
        {
            InitializeComponent();

            // Заполнение полей свойствами аргумента sale 

            



            tbTitle.Text = "Изменение данных работника";
            btnAddNewSale.Content = "Сохранить";

            isEdit = true;
            // Сохраняем sale для доступа вне конструктора
            editSale = ClientProduct;
        }


        private void btnAddNewSale_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                // Обработка случайного нажатия
                MessageBoxResult resClick = MessageBox.Show("Изменить запись?", "Подтверждение редактирования", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                
            }
            else
            {
                var resClick = MessageBox.Show("Добавить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                EF.ClientProduct rent = new EF.ClientProduct();
                rent.IDClient = GetClient.ID;
                rent.IDEmployee = GetEmployee.ID;
                rent.IDProduct = GetProduct.ID;
                rent.SaleStartDate = Convert.ToDateTime(dpSaleDate.SelectedDate);
                rent.SaleEndDate = Convert.ToDateTime(dpReturnDate.SelectedDate);
                ClassHelper.AppData.Context.ClientProduct.Add(rent);
                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Запись об аренде успешно добавлена!");
                this.Close();
            }
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ChooseClient chooseClient = new ChooseClient();
            this.Hide();
            chooseClient.ShowDialog();
            if (GetClient != null)
            {
                btnClient.Content = GetClient.Lname;
            }
            this.ShowDialog();
            
            
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            ChooseProduct chooseProduct= new ChooseProduct();
            this.Hide();
            chooseProduct.ShowDialog();
            if(GetProduct !=null)
            {
                btnProduct.Content = GetProduct.NameProduct;
                if (dpSaleDate.SelectedDate != null && dpReturnDate.SelectedDate != null)
                {
                    tbCost.Text = Calculations.CostOfRent(Convert.ToDateTime(dpSaleDate.SelectedDate), Convert.ToDateTime(dpReturnDate.SelectedDate), GetProduct.Price).ToString();

                }
            }
            this.ShowDialog();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            ChooseEmployee chooseEmployee= new ChooseEmployee();
            this.Hide();
            chooseEmployee.ShowDialog();
            if(GetEmployee != null)
            {
                btnEmployee.Content = GetEmployee.Lname;
            }
            this.ShowDialog();
        }

        private void dpSaleDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetProduct != null && dpReturnDate.SelectedDate != null)
            {
                tbCost.Text = Calculations.CostOfRent(Convert.ToDateTime(dpSaleDate.SelectedDate), Convert.ToDateTime(dpReturnDate.SelectedDate), GetProduct.Price).ToString();

            }
        }

        private void dpReturnDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetProduct != null && dpSaleDate.SelectedDate != null)
            {
                tbCost.Text = Calculations.CostOfRent(Convert.ToDateTime(dpSaleDate.SelectedDate), Convert.ToDateTime(dpReturnDate.SelectedDate), GetProduct.Price).ToString();

            }
        }
    }


}



