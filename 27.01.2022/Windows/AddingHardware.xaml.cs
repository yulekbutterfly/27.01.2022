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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class AddingHardware : Window
    {
        bool isEdit = false;
        EF.Product editProduct = new EF.Product();

        public AddingHardware()
        {
            InitializeComponent();
            cmbType.ItemsSource = ClassHelper.AppData.Context.Type.ToList();
            cmbType.DisplayMemberPath = "NameType";
            cmbType.SelectedIndex = 0;
            cbStatus.Items.Add("Не в аренде");
            cbStatus.Items.Add("В аренде");
            cbStatus.SelectedIndex = 0;

        }
        public AddingHardware(EF.Product product)
        {
            InitializeComponent();
            tbTitle.Text = "Изменение товара";
            btnaddProduct.Content = "Изменить";
            tbProdTitle.Text = product.NameProduct;
            cmbType.SelectedIndex = product.IDType - 1;
            tbCost.Text = product.Price.ToString();
            tbWarranty.Text = product.Warranty.ToString();
            cbStatus.SelectedIndex = Convert.ToInt32(product.IDStatus-1);
            dpDateOfIssue.DataContext = product.DateOfIssue;
            cmbType.DisplayMemberPath = "NameType";
            cbStatus.Items.Add("Не в аренде");
            cbStatus.Items.Add("В аренде");

            isEdit = true;
            editProduct = product;
        }
        private void TitleProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪzxcvbnmasdfghjklqwertyuiopZXCVBNMASDFGHJKLQWERTYUIOP".IndexOf(e.Text) < 0;

        }
        private void Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0987654321".IndexOf(e.Text) < 0;

        }
        private void DateProduct_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ГОДАгодаЛЕТлет1234567890месяцевМесяцев".IndexOf(e.Text) < 0;

        }
        private void btnaddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbProdTitle.Text))
            {
                MessageBox.Show("Поле Название не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCost.Text))
            {
                MessageBox.Show("Поле Цена не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbWarranty.Text))
            {
                MessageBox.Show("Поле Гарантия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(dpDateOfIssue.Text))
            {
                MessageBox.Show("Поле Дата изготовления не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!decimal.TryParse(tbCost.Text, out decimal res))
            {
                MessageBox.Show("Поле Цена должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resClick == MessageBoxResult.No)
            {
                return;
            }
            if(isEdit)
            {
                editProduct.Warranty = tbWarranty.Text;
                editProduct.IDStatus = cbStatus.SelectedIndex + 1;
                editProduct.NameProduct= tbProdTitle.Text;
                editProduct.IDType = cmbType.SelectedIndex + 1;
                editProduct.DateOfIssue = Convert.ToDateTime(dpDateOfIssue.Text);

                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Пользователь изменён");
                this.Close();
                this.Hide();
            }
            else
            {
                EF.Product newProd = new EF.Product();
                newProd.NameProduct = tbProdTitle.Text;
                newProd.IDType = (cmbType.SelectedItem as EF.Type).ID;
                newProd.Price = Convert.ToDecimal(tbCost.Text);
                newProd.Warranty = tbWarranty.Text;
                bool status;
                if (cbStatus.SelectedIndex == 0)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
                newProd.Status = status;
                newProd.DateOfIssue = Convert.ToDateTime(dpDateOfIssue.Text);

                ClassHelper.AppData.Context.Product.Add(newProd);
                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Товар  добавлен");
                this.Close();
                this.Hide();
            }
                

        }

     
    }
}
