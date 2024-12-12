using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    public interface IBasketController
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }
        public ObservableCollection<ProductDataGridItem> BasketItems { get; set; }

        public void AddItems(ObservableCollection<ProductDataGridItem> basketItems);
        public ObservableCollection<ProductDataGridItem> GetItems();
        public String Buy();
    }
}
