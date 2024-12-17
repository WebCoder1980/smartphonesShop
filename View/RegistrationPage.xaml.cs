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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        SesseionInfo CurrentSessionInfo { get; set; }

        (String, int) Captcha { get; set; }

        public RegistrationPage(SesseionInfo sesseion)
        {
            InitializeComponent();

            CurrentSessionInfo = sesseion;

            Captcha = CaptchaService.Get();
            captchaLabel.Content = Captcha.Item1;
        }

        public void registerButton_clicked(object sender, RoutedEventArgs e)
        {
            String login, password, password2, captha;
            login = loginTextBox.Text;

            if (!login.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("В логине можно использовать только буквы или цифры!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (login.Length < 3)
            {
                MessageBox.Show("В логине нужны использовать хотя бы 3 символа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            password = passwordTextBox.Password;
            if (password.Length < 3)
            {
                MessageBox.Show("В пароле нужны использовать хотя бы 3 символа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            password2 = password2TextBox.Password;
            if (password != password2)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            captha = captchaTextBox.Text;
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

            if (capthaNum != Captcha.Item2)
            {
                MessageBox.Show("Капча неверная!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                CurrentSessionInfo.Register(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Регистрация произведена успешно!");

        }
    }
}
