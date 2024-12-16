using SmartphoneShop.Service;
using SmartphoneShop.View;
using SmartphoneShop.View.Header;
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

            HeaderFrame.Navigate(new UnauthorizedHeaderPage(sesseionInfo, "привет, гость"));
            LogoutEvent("гость");
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
            MainFrame.Navigate(new AdminPage(sesseionInfo));
            Title = APP_PREFIX + "администрирование";
        }

        public void logout(object sender, RoutedEventArgs e)
        {
            sesseionInfo.Logout();
            toLoginPage(null, null);
        }

        public void LoginEvent(String newName)
        {
            HeaderFrame.Navigate(new AuthorizedHeaderPage(sesseionInfo, "Привет, " + newName));
        }

        public void LogoutEvent(String newName)
        {
            HeaderFrame.Navigate(new UnauthorizedHeaderPage(sesseionInfo, "Привет, " + newName));
        }
    }
}