﻿using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    public class BasketGuestControoler : IBasketController
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }
        public List<ProductDataGridItem> basketItems;
        public BasketGuestControoler(SesseionInfo CurrentSesseionInfo)
        {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            basketItems = new List<ProductDataGridItem>();
        }

        public BasketGuestControoler(BasketUserController lastBasketController)
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
            return "Войдите в систему, что бы купить!";
        }
    }
}
