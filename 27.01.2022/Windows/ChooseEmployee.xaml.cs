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
    /// Логика взаимодействия для ChooseEmployee.xaml
    /// </summary>
    public partial class ChooseEmployee : Window
    {
        List<string> ListSort = new List<string>()
        {
         "По умолчанию", "По фамилии", "По телефону", "По почте", "По должности"
        };
        public ChooseEmployee()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;
        }
        private void Filter()
        {
            List<EF.Employee> ListEmployee = new List<EF.Employee>();
            ListEmployee = ClassHelper.AppData.Context.Employee.ToList();
            ListEmployee = ListEmployee.Where(i => i.IsDeleted == false).ToList();

            //издевательства (Поиск по нужным параметрам и соритровка по нужным параметрам)
            ListEmployee = ListEmployee.Where(i =>
            i.Lname.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.MName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FIO.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListEmployee = ListEmployee.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    ListEmployee = ListEmployee.OrderBy(i => i.Lname).ToList();
                    break;

                case 2:
                    ListEmployee = ListEmployee.OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    ListEmployee = ListEmployee.OrderBy(i => i.Phone).ToList();
                    break;

                case 4:
                    ListEmployee = ListEmployee.OrderBy(i => i.Email).ToList();
                    break;

                case 5:
                    ListEmployee = ListEmployee.OrderBy(i => i.IDRole).ToList();
                    break;

                default:
                    ListEmployee = ListEmployee.OrderBy(i => i.ID).ToList();
                    break;


            }

            lvEmployee.ItemsSource = ListEmployee;
        }
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void lvEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetEmployee = lvEmployee.SelectedItem as EF.Employee;
            this.Close();
        }
    }
}
