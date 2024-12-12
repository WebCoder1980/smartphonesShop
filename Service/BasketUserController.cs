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
    public class BasketUserController : IBasketController
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }
        public ObservableCollection<ProductDataGridItem> BasketItems { get; set; }
        public BasketUserController(SesseionInfo CurrentSesseionInfo) {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            BasketItems = new ObservableCollection<ProductDataGridItem>();
        }

        public BasketUserController(BasketGuestControoler lastBasketController)
        {
            CurrentSesseionInfo = lastBasketController.CurrentSesseionInfo;
            BasketItems = lastBasketController.BasketItems;
        }

        public void AddItems(ObservableCollection<ProductDataGridItem> basketItems)
        {
            foreach (var i in basketItems)
            {
                BasketItems.Add(i);
            }
        }

        public ObservableCollection<ProductDataGridItem> GetItems()
        {
            return BasketItems;
        }

        public String Buy()
        {
            BasketItems.Where(i => i.IsSelected == true).ToList().All(i => BasketItems.Remove(i));

            return "Куплено!";
        }
    }
}
