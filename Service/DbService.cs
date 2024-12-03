﻿using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Service
{
    internal class DbService : IDbService
    {
        public List<ProductModel> getAllProducts() {
            List<ProductModel> result;
            using (DbContextService db = new DbContextService())
            {
                result = db.products.Where(p => p.count > 0).ToList();
            }

            return result;
        }

        public void AddBasketItems(List<BasketItemModel> basketItems)
        {
            using (DbContextService db = new DbContextService())
            {
                db.basketItems.AddRange(basketItems);
                db.SaveChanges();
            }
        }
    }
}
