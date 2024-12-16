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
    /// Логика взаимодействия для UnauthorizedHeaderPage.xaml
    /// </summary>
    public partial class UnauthorizedHeaderPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }

        public UnauthorizedHeaderPage(SesseionInfo CurrentSesseionInfo, String userLabelName)
        {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            InitializeComponent();
            userLabel.Content = userLabelName;
        }

        private void toRegistrationPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toRegistrationPage(null, null);
        }

        private void toLoginPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toLoginPage(null, null);
        }

        private void toProductsPage(object sender, RoutedEventArgs e)
        {
            CurrentSesseionInfo.ParentWindow.toProductsPage(null, null);
        }
    }
}
