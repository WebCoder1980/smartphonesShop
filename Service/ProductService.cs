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

            foreach (var i in CurrentSesseionInfo.DatabaseService.getAllProducts())
            {
                ProductsItems.Add(new ProductDataGridItem(i));
            }
        }
    }
}
