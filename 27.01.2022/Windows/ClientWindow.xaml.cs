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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            lvClient.ItemsSource = ClassHelper.AppData.Context.Client.ToList();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;
        }
        List<string> ListSort = new List<string>()
        {
         "По умолчанию", "По фамилии", "По имени", "По почте"
        };


        private void Filter()
        {
            List<EF.Client> ListClient = new List<EF.Client>();
            ListClient = ClassHelper.AppData.Context.Client.ToList();
            ListClient = ListClient.Where(i => i.IsDeleted == false).ToList();

            //издевательства (Поиск по нужным параметрам и соритровка по нужным параметрам)
            ListClient = ListClient.Where(i =>
            i.Lname.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.MName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListClient  = ListClient .OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    ListClient  = ListClient .OrderBy(i => i.Lname).ToList();
                    break;

                case 2:
                    ListClient  = ListClient .OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    ListClient  = ListClient .OrderBy(i => i.Phone).ToList();
                    break;

                case 4:
                    ListClient  = ListClient .OrderBy(i => i.Email).ToList();
                    break;

                case 5:
                    ListClient = ListClient.OrderBy(i => i.PassportS).ToList();
                    break;

                case 6:
                    ListClient = ListClient.OrderBy(i => i.DateOfBirth).ToList();
                    break;

                case 7:
                    ListClient = ListClient.OrderBy(i => i.IDGender).ToList();
                    break;

                default:
                    ListClient = ListClient.OrderBy(i => i.ID).ToList();
                    break;


            }

            lvClient.ItemsSource = ListClient;
        }

        private void btn_addClient_Click(object sender, RoutedEventArgs e)
        {
            lvClient.ItemsSource = ClassHelper.AppData.Context.Client.ToList();
            AddingClient addingclient = new AddingClient();
            this.Hide();
            addingclient.ShowDialog();
            this.ShowDialog();
            //Filter();
            //this.Close();


        }


        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }


        //Удаление пользователя 
        private void lvClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                //try
                //{
                if (lvClient.SelectedItem is EF.Client)
                {
                    var resmsg = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resmsg == MessageBoxResult.No)
                    {
                        return;
                    }
                    var stf = lvClient.SelectedItem as EF.Client;
                    stf.IsDeleted = true;
                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Клиент успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Filter();
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}
            }
        }



      

        private void lvClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {  
            
            if (lvClient.SelectedItem is EF.Client)
            {
                 var client  = lvClient.SelectedItem as EF.Client;
                AddingClient addingclient  = new AddingClient (client);
                addingclient.ShowDialog();
                Filter();
            }

        }
    }











    //public ClientWindow()
    //{
    //    InitializeComponent();
    //    cmbSort.ItemsSource = ListSort;
    //    cmbSort.SelectedIndex = 0;

    //}
    //private void Filter()
    //{
    //    List<EF.Client> ListClient = new List<EF.Client>();
    //    ListClient = ClassHelper.AppData.Context.Client.ToList();


    //    //издевательства 
    //    ListClient = ListClient.Where(i =>
    //    i.Lname.ToLower().Contains(txtSearch.Text.ToLower()) ||
    //    i.FName.ToLower().Contains(txtSearch.Text.ToLower()) ||
    //    i.MName.ToLower().Contains(txtSearch.Text.ToLower()) ||
    //    //i.FIO.ToLower().Contains(txtSearch.Text.ToLower()) ||
    //    i.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
    //    i.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();


    //    switch (cmbSort.SelectedIndex)
    //    {
    //        case 0:
    //            ListClient = ListClient.OrderBy(i => i.ID).ToList();
    //            break;

    //        case 1:
    //            ListClient = ListClient.OrderBy(i => i.Lname).ToList();
    //            break;

    //        case 2:
    //            ListClient = ListClient.OrderBy(i => i.FName).ToList();
    //            break;

    //        case 3:
    //            ListClient = ListClient.OrderBy(i => i.Phone).ToList();
    //            break;

    //        case 4:
    //            ListClient = ListClient.OrderBy(i => i.Email).ToList();
    //            break;


    //        default:
    //            ListClient = ListClient.OrderBy(i => i.ID).ToList();
    //            break;


    //    }

    //    lvClient.ItemsSource = ListClient;
    //}

    // private void btn_addempl_Click(object sender, RoutedEventArgs e)
    // {
    //    AddEmployeeWindow addemployeeWindow = new AddEmployeeWindow();
    //    this.Hide();
    //    addemployeeWindow.ShowDialog();
    //    lvClient.ItemsSource = ClassHelper.AppData.Context.Employee.ToList();
    //    Filter();
    //}







}
