using ProductCatalog.Model;
using ProductCatalog.Service;
using SmartphoneShop.Control;
using SmartphoneShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ProductDataGridItem> productsDataGridItems { get; set; }

        SesseionInfo CurrentSesseionInfo { get; set; }
        public BasketPage(SesseionInfo sessionInfo)
        {
            InitializeComponent();
            CurrentSesseionInfo = sessionInfo;

            productsDataGridItems = new ObservableCollection<ProductDataGridItem>();
            productsDataGrid.ItemsSource = productsDataGridItems;

            foreach (var i in CurrentSesseionInfo.BasketController.GetItems())
            {
                productsDataGridItems.Add(i);
            }
        }

        public void refreshProductsDataGridItems()
        {
            var newCollection = new ObservableCollection<ProductDataGridItem>();

            foreach (var i in CurrentSesseionInfo.BasketController.GetItems())
            {
                newCollection.Add(i);
            }

            productsDataGridItems = newCollection;
            productsDataGrid.ItemsSource = newCollection;
        }

        private void buyButtonClicked(object sender, RoutedEventArgs e)
        {
            List <ProductModel> selectedProducts = new List<ProductModel>();
            foreach (var i in productsDataGridItems)
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

            String result = CurrentSesseionInfo.BasketController.BuyAll();
            refreshProductsDataGridItems();
            MessageBox.Show(result, "Сообщение", MessageBoxButton.OK, MessageBoxImage.None);
        }
    }
}
