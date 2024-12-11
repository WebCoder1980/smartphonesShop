using ProductCatalog.Model;
using SmartphoneShop.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartphoneShop.Service
{
    public class BasketUserController : IBasketController
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }
        public List<ProductDataGridItem> basketItems;
        public BasketUserController(SesseionInfo CurrentSesseionInfo) {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            basketItems = new List<ProductDataGridItem>();
        }

        public BasketUserController(BasketGuestControoler lastBasketController)
        {
            CurrentSesseionInfo = lastBasketController.CurrentSesseionInfo;
            basketItems = lastBasketController.basketItems;
        }

        public void AddItems(List<ProductDataGridItem> basketItems)
        {
            this.basketItems.AddRange(basketItems);
        }

        public List<ProductDataGridItem> GetItems()
        {
            return basketItems;
        }

        public String BuyAll()
        {
            basketItems = basketItems.Where(i => i.IsSelected == false).ToList();

            return "Куплено!";
        }
    }
}
