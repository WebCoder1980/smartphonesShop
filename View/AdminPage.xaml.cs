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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }

        public AdminPage(SesseionInfo CurrentSesseionInfo)
        {
            InitializeComponent();

            this.CurrentSesseionInfo = CurrentSesseionInfo;
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
