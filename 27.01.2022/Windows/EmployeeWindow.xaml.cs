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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        List<string> ListSort = new List<string>()
        {
         "По умолчанию", "По фамилии", "По телефону", "По почте", "По должности"
        };

        public EmployeeWindow()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;

        }

        private void Filter()
        {
            List<EF.Employee> ListEmployee = new List<EF.Employee>();
            ListEmployee = ClassHelper.AppData.Context.Employee.ToList();
            ListEmployee = ListEmployee.Where(i => i.IsDeleted==false).ToList();

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

        private void btn_addempl_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addemployeeWindow = new AddEmployeeWindow();
            lvEmployee.ItemsSource = ClassHelper.AppData.Context.Employee.ToList();
            this.Hide();
            addemployeeWindow.ShowDialog();
            this.ShowDialog();
            Filter();
        }

        // Изменение пользователя
        //private void LV_Employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (lvEmployee.SelectedItem is EmployeeWindow)
        //    {
        //        EmployeeWindow empl = lvEmployee.SelectedItem as EmployeeWindow;
        //        AddEmployeeWindow editEmployee = new AddEmployeeWindow(empl);
        //        editEmployee.ShowDialog();
        //        Filter();
        //    }
        //}


        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }





        //Удаление пользователя 
        private void lvEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                //try
                //{
                    if (lvEmployee.SelectedItem is EF.Employee)
                    {
                        var resmsg = MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvEmployee.SelectedItem as EF.Employee;
                        stf.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Пользователь успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}
            }
        }


        private void lvEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvEmployee.SelectedItem is EF.Employee)
            {
                var empl = lvEmployee.SelectedItem as EF.Employee;
                AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(empl);
                addEmployeeWindow.ShowDialog();
                Filter();
            }
        }
    }
}

