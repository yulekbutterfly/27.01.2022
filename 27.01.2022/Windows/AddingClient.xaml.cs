using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using static _27._01._2022.ClassHelper.AppData;
using static _27._01._2022.ClassHelper.ValidationResult;
using static System.Data.Entity.Validation.DbEntityValidationResult;


namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class AddingClient : Window
    {

        bool isEdit = false;
        EF.Client editClient = new EF.Client();

        public AddingClient()
        {
            InitializeComponent();
            cmbGnd.Items.Add("Мужской");
            cmbGnd.Items.Add("Женский");
            cmbGnd.SelectedIndex = 0;
            isEdit = false;
        }


        public AddingClient(EF.Client client)
        {
            InitializeComponent();
            LNameClient.Text = client.Lname;
            FName.Text = client.FName;
            MName.Text = client.MName;
            Phone.Text = client.Phone;
            Email.Text = client.Email;
            SPassporta.Text = client.PassportS;
            NPassporta.Text = client.PassportN;
            Birth.DataContext = client.DateOfBirth;
            cmbGnd.SelectedIndex = Convert.ToInt32(client.IDGender - 1);
            cmbGnd.Items.Add("Мужской");
            cmbGnd.Items.Add("Женский");
            tbTitle.Text = "Изменение данных клиента";
            btnaddClients.Content = "Сохранить";


            isEdit = true;
            editClient = client;
        }
        private void FIO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪ".IndexOf(e.Text) < 0;

        }
        private void Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0987654321".IndexOf(e.Text) < 0;

        }
        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890@.".IndexOf(e.Text) < 0;

        }
        private void cmbGnd_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

         

        private void btnaddClients_Click(object sender, RoutedEventArgs e)
        {
            bool IsValidEmail(string email)
            {
                email = Email.Text;
                string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }
            //валидация
            if (ValidationNameLNameMName(LNameClient.Text) == false)
            {
                MessageBox.Show("Поле фамилия не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ValidationNameLNameMName(FName.Text) == false)
            {
                MessageBox.Show("Поле Имя не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ValidationNameLNameMName(MName.Text) == false)
            {
                MessageBox.Show("Поле Отчество не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ValidationPhone(Phone.Text) == false)
            {
                MessageBox.Show("Поле Телефон не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (IsValidEmail(Email.Text) == false)
            {
                MessageBox.Show("Поле Почта заполнено неккорректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (isEdit)
            //Изменение пользователя 
            {
                var resClick = MessageBox.Show("Изменить пользователя?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                //try
                //{
                    editClient.Lname = LNameClient.Text;
                    editClient.FName = FName.Text;
                    editClient.MName = MName.Text;
                    editClient.Phone = Phone.Text;
                    editClient.Email = Email.Text;
                    editClient.IDGender = cmbGnd.SelectedIndex + 1;
                    Context.SaveChanges();
                    MessageBox.Show("Пользователь изменён");
                    this.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                //try
                //{
                    
                    try
                    {
                        EF.Client newclient = new EF.Client();
                        newclient.Lname = LNameClient.Text;
                        newclient.FName = FName.Text;
                        newclient.MName = MName.Text;
                        newclient.Phone = Phone.Text;
                        newclient.Email = Email.Text;
                        newclient.PassportS = SPassporta.Text;
                        newclient.PassportN = NPassporta.Text;
                        newclient.DateOfBirth = Birth.SelectedDate.Value;
                        newclient.IDGender = cmbGnd.SelectedIndex + 1;
                        

                        Context.Client.Add(newclient);
                        Context.SaveChanges();

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            MessageBox.Show(" ");
   
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
    
                            }
                        }
                    }
                    
                    MessageBox.Show("Пользователь добавлен");
                    this.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}


            }
        }

        
    }
}