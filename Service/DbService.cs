using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Service
{
    public class DbService : IDbService
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

        public UserModel login(String name, String password)
        {
            using (DbContextService db = new DbContextService())
            {
                var user = db.users.SingleOrDefault(u => u.name == name && u.password == password);

                if (user == null)
                {
                    throw new InvalidOperationException("Пользователь с такими данными не найден.");
                }
                return user;
            }
        }
    }
}
