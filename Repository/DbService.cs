using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartphoneShop.Repository
{
    public class DbService
    {
        public List<ProductModel> getAllProducts()
        {
            List<ProductModel> result;
            using (DbContextService db = new DbContextService())
            {
                result = db.products.Where(p => p.count > 0).ToList();
            }

            return result;
        }

        public List<ProductModel> GetBasketItems(int userId)
        {
            List<ProductModel> result;

            using (DbContextService db = new DbContextService())
            {
                List<BasketItemModel> tmpList = new List<BasketItemModel>();

                tmpList = db.basketitems.Where(p => p.isbougth == false).ToList();

                foreach (var item in tmpList)
                {
                    db.Entry(item).Reference(b => b.user).Load();

                    db.Entry(item).Reference(b => b.product).Load();
                }
                result = tmpList.Select(b => new ProductModel(b.product.id, b.product.name, b.product.price, b.product.count)).ToList();
            }

            return result;
        }
        public void AddBasketItems(List<BasketItemModel> basketItems)
        {
            using (DbContextService db = new DbContextService())
            {
                db.basketitems.AddRange(basketItems);
                db.SaveChanges();
            }
        }

        public UserModel login(string name, string password)
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

        public void register(string name, string password)
        {
            using (DbContextService db = new DbContextService())
            {
                var existingUser = db.users.SingleOrDefault(u => u.name == name);

                if (existingUser != null)
                {
                    throw new InvalidOperationException("Пользователь с таким именем уже существует.");
                }

                UserModel newUser = new UserModel
                {
                    name = name,
                    password = password,
                    role = 2
                };

                db.users.Add(newUser);

                db.SaveChanges();
            }
        }
    }
}
