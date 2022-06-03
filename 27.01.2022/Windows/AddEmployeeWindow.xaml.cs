using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;


namespace _27._01._2022.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        bool isEdit = false;
        EF.Employee editEmployee = new EF.Employee();
        string pathPhoto;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            //cmbRole.ItemsSource = ClassHelper.AppData.Context.Role.ToList();
            //cmbRole.DisplayMemberPath = "NameRole";
            //cmbRole.SelectedItem = "0";

            cmbRole.Items.Add("менеджер по продажам");
            cmbRole.Items.Add("продавец");
            cmbRole.Items.Add("директор");
            cmbRole.Items.Add("заведующий");
            cmbRole.Items.Add("бухгалтер");
            cmbRole.Items.Add("it -специалист");
            cmbRole.SelectedIndex = 0;
            isEdit = false;
        }

        public AddEmployeeWindow(EF.Employee employee)
        {
            InitializeComponent();
            //cmbRole.ItemsSource = ClassHelper.AppData.Context.Role.ToList();
            //cmbRole.DisplayMemberPath = "NameRole";
            Lname.Text = employee.Lname;
            FName.Text = employee.FName;
            MName.Text = employee.MName;
            Phone.Text = employee.Phone;
            Email.Text = employee.Email;
            Login.Text = employee.Login;
            Password.Text = employee.Password;
            cmbRole.SelectedIndex = Convert.ToInt32(employee.IDRole - 1);
            cmbRole.Items.Add("менеджер по продажам");
            cmbRole.Items.Add("продавец");
            cmbRole.Items.Add("директор");
            cmbRole.Items.Add("заведующий");
            cmbRole.Items.Add("бухгалтер");
            cmbRole.Items.Add("it -специалист");
            //cmbRole.SelectedIndex = employee.IDRole - 1; 

            tbTitle.Text = "Изменение данных работника";
            btnadd.Content = "Сохранить";

            isEdit = true;
            editEmployee = employee;

        }
        //private void IlyaTvar(object sender, EventArgs e)
        //{
        //    if (((Control.ModifierKeys & Keys.Control) == Keys.Control))
        //}
        private void FIO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪ".IndexOf(e.Text) < 0;

        }
        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0987654321".IndexOf(e.Text) < 0;

        }
        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890@.".IndexOf(e.Text) < 0;

        }



        private void btnadd_Click(object sender, RoutedEventArgs e)

        {
            bool IsValidEmail(string email)
            {
                string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }
            //валидация
            if (ClassHelper.ValidationResult.ValidationNameLNameMName(Lname.Text) == false)
            {
                MessageBox.Show("Поле фамилия не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClassHelper.ValidationResult.ValidationNameLNameMName(FName.Text) == false)
            {
                MessageBox.Show("Поле Имя не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClassHelper.ValidationResult.ValidationNameLNameMName(MName.Text) == false)
            {
                MessageBox.Show("Поле Отчество не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClassHelper.ValidationResult.ValidationPhone(Phone.Text) == false)
            {
                MessageBox.Show("Поле Телефон не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClassHelper.ValidationResult.ValidationLogin(Login.Text) == false)
            {
                MessageBox.Show("Поле Логин не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ClassHelper.ValidationResult.ValidationPassword(Password.Text) == false) 
            {
                MessageBox.Show("Поле Пароль не соотвествует стандартам", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var authUser = ClassHelper.AppData.Context.Employee.ToList().
             Where(i => i.Login == Login.Text && i.Login!=editEmployee.Login).FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Данный логин занят!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (IsValidEmail(Email.Text)==false)
            {
                MessageBox.Show("Поле Почта заполнено неккорректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (isEdit) //Изменение пользователя 
            {
                var resClick = MessageBox.Show("Изменить пользователя?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    editEmployee.Lname = Lname.Text;
                    editEmployee.FName = FName.Text;
                    editEmployee.MName = MName.Text;
                    editEmployee.Phone = Phone.Text;
                    editEmployee.Email = Email.Text;
                    editEmployee.IDRole = cmbRole.SelectedIndex+1;
                    editEmployee.Login = Login.Text;
                    editEmployee.Password = Password.Text;

                    if (pathPhoto != null)
                    {
                        editEmployee.Photo = File.ReadAllBytes(pathPhoto);
                    }

                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Пользователь изменён");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                    EF.Employee newstaff = new EF.Employee();
                    newstaff.Lname = Lname.Text;
                    newstaff.FName = FName.Text;
                    newstaff.MName = MName.Text;
                    newstaff.Phone = Phone.Text;
                    newstaff.Email = Email.Text;
                    newstaff.IDRole = cmbRole.SelectedIndex+1;
                    newstaff.Login = Login.Text;
                    newstaff.Password = Password.Text;
                    if (pathPhoto != null)
                    {
                        editEmployee.Photo = File.ReadAllBytes(pathPhoto);
                    }

                    ClassHelper.AppData.Context.Employee.Add(newstaff);
                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");
                    //this.ShowDialog();
                    //this.Hide();
                    this.Close();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    //this.ShowDialog();
                    //this.Hide();
                    this.Close();
                }
           }   
        
        }
        

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnaddphoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            if (openFile.ShowDialog() == true)
            {
                //photoUser.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;

            }
        }
    }
}


//if (string.IsNullOrWhiteSpace(Lname.Text))
//{
//    MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
//if (string.IsNullOrWhiteSpace(FName.Text))
//{
//    MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
//if (!Int32.TryParse(Phone.Text, out int res))
//{
//    MessageBox.Show("Поле Телефон должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
//if (Phone.Text.Length > 12)
//{
//    MessageBox.Show("Поле Телефон содержит больше 12 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
//if (string.IsNullOrWhiteSpace(Login.Text))
//{
//    MessageBox.Show("Поле Login не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
//if (string.IsNullOrWhiteSpace(Password.Text))
//{
//    MessageBox.Show("Поле Пароль не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}
