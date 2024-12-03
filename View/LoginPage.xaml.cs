using SmartphoneShop.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartphoneShop.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }
        public LoginPage(SesseionInfo sesseion)
        {
            InitializeComponent();

            CurrentSesseionInfo = sesseion;
        }

        private void loginButton_clicked(object sender, RoutedEventArgs e)
        {
            String login, password, captha;
            login = loginTextBox.Text;
            password = passwordTextBox.Password;
            captha = capthaTextBox.Text;

            int capthaNum;
            try
            {
                capthaNum = Int32.Parse(captha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильная капча!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (capthaNum != 7)
            {
                MessageBox.Show("Неправильная капча!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                CurrentSesseionInfo.Login(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильные данные для входа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Вход произведён успешно!");

        }
    }
}
