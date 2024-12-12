using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Repository
{
    internal interface IDbService
    {
        public List<ProductModel> getAllProducts();
        public void AddBasketItems(List<BasketItemModel> basketItems);
        public UserModel login(string name, string password);
        public void register(string name, string password);
    }
}
