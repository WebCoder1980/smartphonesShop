using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    public interface IBasketController
    {
        public void AddItems(List<ProductDataGridItem> basketItems);
        public List<ProductDataGridItem> GetItems();
        public String BuyAll();
    }
}
