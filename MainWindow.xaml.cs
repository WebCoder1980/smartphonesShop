using SmartphoneShop.Service;
using SmartphoneShop.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartphoneShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const String APP_PREFIX = "MProducts - ";

        SesseionInfo sesseionInfo;
        BasketController basketController;

        public MainWindow()
        {
            InitializeComponent();

            sesseionInfo = new SesseionInfo(this);

            toProductsPage(null, null);
        }

        public void toProductsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage(sesseionInfo));
            Title = APP_PREFIX + "товары";
        }

        public void toBasketPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BasketPage(sesseionInfo));
            Title = APP_PREFIX + "корзина";
        }

        public void toLoginPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginPage(sesseionInfo));
            Title = APP_PREFIX + "войти в систему";
        }

        public void toRegistrationPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage(sesseionInfo));
            Title = APP_PREFIX + "зарегистрироваться";
        }

        public void toAdminPage(object sender, RoutedEventArgs e)
        {
            throw new Exception("Админ панель ещё недоступна");
            //MainFrame.Navigate();
            //Title = APP_PREFIX + "зарегистрироваться";
        }

        public void logout(object sender, RoutedEventArgs e)
        {
            sesseionInfo.Logout();
        }

        public void LoginEvent(String newName)
        {
            userLabel.Content = "Привет, " + newName;

            loginButton.Visibility = Visibility.Hidden;
            registerButton.Visibility = Visibility.Hidden;
            logoutButton.Visibility = Visibility.Visible;
        }

        public void LogoutEvent(String newName)
        {
            userLabel.Content = "Привет, " + newName;

            loginButton.Visibility = Visibility.Visible;
            registerButton.Visibility = Visibility.Visible;
            logoutButton.Visibility = Visibility.Hidden;
        }
    }
}