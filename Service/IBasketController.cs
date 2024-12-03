using ProductCatalog.Model;
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
        public void AddItems(List<ProductModel> basketItems);
        public List<ProductModel> GetItems();
        public String BuyAll();
    }
}
