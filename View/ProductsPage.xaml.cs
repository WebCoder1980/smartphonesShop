using ProductCatalog.Service;
using SmartphoneShop.Control;
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
        ObservableCollection<ProductDataGridItem> productsDataGridItems { get; set; }
        DbService dbService;
        public ProductsPage()
        {
            InitializeComponent();
            productsDataGridItems = new ObservableCollection<ProductDataGridItem>();
            productsDataGrid.ItemsSource = productsDataGridItems;

            dbService = new DbService();

            foreach (var i in dbService.getAllProducts())
            {
                productsDataGridItems.Add(new ProductDataGridItem(i));
            }
        }
    }
}
