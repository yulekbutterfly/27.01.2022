using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class AddingClient : Window
    {       
        
       bool isEdit = false;
       EF.Client editClient= new EF.Client();
    
        public AddingClient()
        {
            InitializeComponent();
        


            isEdit = false;
            


        }
   
        
        public AddingClient(EF.Client client)
        {
            Lname.Text = client.Lname;
            FName.Text = client.FName;
            MName.Text = client.MName;
            Phone.Text = client.Phone;
            Email.Text = client.Email;
            SPassporta.Text = client.PassportS;
            NPassporta.Text = client.PassportN;
            Birth.DataContext = client.DateOfBirth;




            isEdit = true;
            editClient = client;
        }

        private void btnaddClients_Click(object sender, RoutedEventArgs e)
        {
            bool IsValidEmail(string email)
            {
                string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }
            //валидация
            if (string.IsNullOrWhiteSpace(Lname.Text))
            {
                MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(FName.Text))
            {
                MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Phone.Text))
            {
                MessageBox.Show("Поле Телефон не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                MessageBox.Show("Поле Почта  не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(SPassporta.Text))
            {
                MessageBox.Show("Поле Серия паспорта  не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            
            if (Phone.Text.Length > 12)
            {
                MessageBox.Show("Поле Телефон содержит больше 12 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsValidEmail(Email.Text) == false)
            {
                MessageBox.Show("Поле Почта заполнено неккорректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Int32.TryParse(Phone.Text, out int res))
            {
                MessageBox.Show("Поле Телефон должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    EF.Client newclient=new EF.Client();
                    newclient.Lname = Lname.Text;
                    newclient.FName = FName.Text;
                    newclient.MName = MName.Text;
                    newclient.Phone = Phone.Text;
                    newclient.Email = Email.Text;
                   
                    newclient.PassportS =  SPassporta.Text;
                    newclient.PassportN = NPassporta.Text;
                    ClassHelper.AppData.Context.Client.Add(newclient);
                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Клиент добавлен");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cmbGnd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
