using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Model;
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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        SesseionInfo sesseionInfo;
        public ProductsPage(SesseionInfo sesseionInfo)
        {
            InitializeComponent();

            this.sesseionInfo = sesseionInfo;


            productsDataGrid.ItemsSource = sesseionInfo.ProductServ.ProductsItems;
        }

        private void toBasketButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sesseionInfo.CurrentUser == null)
            {
                MessageBox.Show("Войдите в систему что бы добавлять товары в корзину!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<ProductModel> selectedProducts = new List<ProductModel>();
            foreach (var i in sesseionInfo.ProductServ.ProductsItems)
            {
                if (i.IsSelected == true)
                {
                    selectedProducts.Add(new ProductModel(i));
                    i.IsSelected = false;
                }
            }

            if (selectedProducts.Count() == 0)
            {
                MessageBox.Show("Ни один продукт не был выбран", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<ProductDataGridItem> selectedProductsGridItems = new List<ProductDataGridItem>();

            foreach (var i in selectedProducts)
            {
                i.count = 1;
                selectedProductsGridItems.Add(new ProductDataGridItem(i));
            }

            sesseionInfo.BasketController.AddItems(new ObservableCollection<ProductDataGridItem>(selectedProductsGridItems));

        }
    }
}
