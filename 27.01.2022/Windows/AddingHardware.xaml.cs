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
        EF.Product editEmployee = new EF.Product();

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

        private void btnaddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbProdTitle.Text))
            {
                MessageBox.Show("Поле Название не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Cost.Text))
            {
                MessageBox.Show("Поле Цена не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Warranty.Text))
            {
                MessageBox.Show("Поле Гарантия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDateOfIssue.Text))
            {
                MessageBox.Show("Поле Дата изготовления не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!decimal.TryParse(Cost.Text, out decimal res))
            {
                MessageBox.Show("Поле Цена должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resClick == MessageBoxResult.No)
            {
                return;
            }
            try
            {
                EF.Product newProd = new EF.Product();
                newProd.NameProduct = tbProdTitle.Text;
                newProd.IDType = (cmbType.SelectedItem as EF.Type).ID;
                newProd.Price = Convert.ToDecimal(Cost.Text);
                newProd.Warranty = Warranty.Text;
                bool status;
                if(cbStatus.SelectedIndex == 0)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
                newProd.Status = status;
                newProd.DateOfIssue = Convert.ToDateTime(tbDateOfIssue.Text);

                ClassHelper.AppData.Context.Product.Add(newProd);
                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Товар  добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
