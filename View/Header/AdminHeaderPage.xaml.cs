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

namespace SmartphoneShop.View.Header
{
    /// <summary>
    /// Логика взаимодействия для AdminHeaderPage.xaml
    /// </summary>
    public partial class AdminHeaderPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }

        public AdminHeaderPage(SesseionInfo CurrentSesseionInfo, String userLabelName)
        {
            InitializeComponent();
            this.CurrentSesseionInfo = CurrentSesseionInfo;

            userLabel.Content = userLabelName;
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.logout(null, null);
        }

        private void toProductsPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toProductsPage(null, null);
        }

        private void toBasketPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toBasketPage(null, null);
        }

        private void toAdminPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toAdminPage(null, null);
        }
    }
}
