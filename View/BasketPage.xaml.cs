using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }
        public BasketPage(SesseionInfo sessionInfo)
        {
            InitializeComponent();
            CurrentSesseionInfo = sessionInfo;

            productsDataGrid.ItemsSource = CurrentSesseionInfo.BasketController.BasketItems;

            CurrentSesseionInfo.BasketController.RefreshDataGrid();
        }

        private void buyButtonClicked(object sender, RoutedEventArgs e)
        {
            List <ProductModel> selectedProducts = new List<ProductModel>();
            foreach (var i in CurrentSesseionInfo.BasketController.BasketItems)
            {
                if (i.IsSelected == true)
                {
                    selectedProducts.Add(new ProductModel(i));
                }
            }
               
            if (selectedProducts.Count() == 0)
            {
                MessageBox.Show("Ни один продукт не был выбран", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            String result = CurrentSesseionInfo.BasketController.Buy();
            MessageBox.Show(result, "Сообщение", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void deleteButtonClicked(object sender, RoutedEventArgs e)
        {
            List<ProductModel> selectedProducts = new List<ProductModel>();
            foreach (var i in CurrentSesseionInfo.BasketController.BasketItems)
            {
                if (i.IsSelected == true)
                {
                    selectedProducts.Add(new ProductModel(i));
                }
            }

            if (selectedProducts.Count() == 0)
            {
                MessageBox.Show("Ни один продукт не был выбран", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            String result = CurrentSesseionInfo.BasketController.Delete();
            MessageBox.Show(result, "Сообщение", MessageBoxButton.OK, MessageBoxImage.None);
        }
    }
}
