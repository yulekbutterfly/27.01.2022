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
    /// Логика взаимодействия для ChooseClient.xaml
    /// </summary>
    public partial class ChooseClient : Window
    {
        List<string> ListSort = new List<string>()
        {
         "По умолчанию", "По фамилии", "По телефону", "По почте", "По должности"
        };
        public ChooseClient()
        {
            InitializeComponent();
            lvClient.ItemsSource = ClassHelper.AppData.Context.Client.ToList();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;
        }
        private void Filter()
        {
            List<EF.Client> ListClient = new List<EF.Client>();
            ListClient = ClassHelper.AppData.Context.Client.ToList();


            //издевательства 
            ListClient = ListClient.Where(i =>
            i.Lname.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.MName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            //i.FIO.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();


            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListClient = ListClient.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    ListClient = ListClient.OrderBy(i => i.Lname).ToList();
                    break;

                case 2:
                    ListClient = ListClient.OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    ListClient = ListClient.OrderBy(i => i.Phone).ToList();
                    break;

                case 4:
                    ListClient = ListClient.OrderBy(i => i.Email).ToList();
                    break;


                default:
                    ListClient = ListClient.OrderBy(i => i.ID).ToList();
                    break;


            }

            lvClient.ItemsSource = ListClient;
        }
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void lvClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetClient = lvClient.SelectedItem as EF.Client;
            this.Close();
        }
    }
}
