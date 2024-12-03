﻿using SmartphoneShop.View;
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
        public MainWindow()
        {
            InitializeComponent();
            toProductsPage();
        }

        private void toProductsPage()
        {
            MainFrame.Navigate(new ProductsPage());
            Title = APP_PREFIX + "товары";
        }
    }
}