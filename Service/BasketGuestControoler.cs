using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    internal class BasketGuestControoler : IBasketController
    {
        List<ProductModel> basketItems;
        public BasketGuestControoler()
        {
            basketItems = new List<ProductModel>();
        }

        public void AddItems(List<ProductModel> basketItems)
        {
            this.basketItems.AddRange(basketItems);
        }

        public List<ProductModel> GetItems()
        {
            return basketItems;
        }

        public String BuyAll()
        {
            return "Войдите в систему, что бы купить!";
        }
    }
}
