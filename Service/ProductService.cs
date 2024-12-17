using ProductCatalog.Model;
using SmartphoneShop.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartphoneShop.Service
{
    public class ProductService
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }
        public ObservableCollection<ProductDataGridItem> ProductsItems { get; set; }
        public ProductService(SesseionInfo CurrentSessionInfo) {
            this.CurrentSesseionInfo = CurrentSessionInfo;

            ProductsItems = new ObservableCollection<ProductDataGridItem>();

            getAll();
        }
        public void getAll() {
            ProductsItems.Clear();

            List<ProductModel> products;
            if (CurrentSesseionInfo.CurrentUser != null && CurrentSesseionInfo.CurrentUser.role == 1)
            {
                products = CurrentSesseionInfo.DatabaseService.getAllProducts();
            }
            else
            {
                products = CurrentSesseionInfo.DatabaseService.getAvailableProducts();
            }

            foreach (var i in products)
            {
                ProductsItems.Add(new ProductDataGridItem(i));
            }
        }
    }
}
