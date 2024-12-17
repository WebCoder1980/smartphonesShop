using Microsoft.EntityFrameworkCore;
using ProductCatalog.Model;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D.Converters;

namespace SmartphoneShop.Repository
{
    public class DbService
    {
        public List<ProductModel> getAllProducts()
        {
            List<ProductModel> result;
            using (DbContextService db = new DbContextService())
            {
                result = db.products.OrderBy(b => b.id).ToList();
            }

            return result;
        }

        public List<ProductModel> getAvailableProducts()
        {
            List<ProductModel> result;
            using (DbContextService db = new DbContextService())
            {
                result = db.products.Where(p => p.count > 0).OrderBy(b => b.id).ToList();
            }

            return result;
        }

        public List<ProductModel> GetBasketItems(int userId)
        {
            List<ProductModel> result;

            using (DbContextService db = new DbContextService())
            {
                List<BasketItemModel> tmpList = new List<BasketItemModel>();

                tmpList = db.basketitems.Where(p => p.userid == userId && p.isbougth == false).ToList();

                foreach (var item in tmpList)
                {
                    db.Entry(item).Reference(b => b.user).Load();

                    db.Entry(item).Reference(b => b.product).Load();
                }
                result = tmpList.Select(b => new ProductModel(b.product.id, b.product.name, b.product.price, b.count)).OrderBy(b => b.id).ToList();
            }

            return result;
        }
        public void AddBasketItems(List<BasketItemModel> newItems)
        {
            using (DbContextService db = new DbContextService())
            {
                foreach (var i in newItems)
                {
                    if (db.basketitems.Where(j => j.userid == i.userid && j.productid == i.productid && j.isbougth == false).Count() == 0)
                    {
                        db.basketitems.Add(i);
                        continue;
                    }

                    db.basketitems.Where(j => j.userid == i.userid && j.productid == i.productid).ExecuteUpdate(j => j.SetProperty(k => k.count, k => k.count + i.count));
                }
                db.SaveChanges();
            }
        }

        public String? BuyBasketItems(List<BasketItemModel> items)
        {
            using (DbContextService db = new DbContextService())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var i in items)
                        {
                            var product = db.products.SingleOrDefault(p => p.id == i.productid);
                            if (product == null || product.count < i.count)
                            {
                                throw new Exception($"Недостаточно товара с id {i.productid}. Доступно: {product.count}, требуется: {i.count}");
                            }

                            db.basketitems.Where(j => j.userid == i.userid && j.productid == i.productid)
                                .ExecuteUpdate(j => j.SetProperty(k => k.isbougth, k => true));

                            db.products.Where(j => j.id == i.productid)
                                .ExecuteUpdate(j => j.SetProperty(k => k.count, k => k.count - i.count));
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Покупка отменена: {ex.Message}";
                    }

                    return null;
                }
            }
        }

        public void DeleteBasketItems(List<BasketItemModel> items)
        {
            using (DbContextService db = new DbContextService())
            {
                foreach (var i in items)
                {
                    db.basketitems.RemoveRange(db.basketitems.Where(j => j.userid == i.userid && j.productid == i.productid && j.isbougth == false).ToList());
                }
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

        public ProductModel GetProduct(int id)
        {
            using (DbContextService db = new DbContextService())
            {
                return db.products.SingleOrDefault(p => p.id == id);
            }
        }

        public bool UpdateProduct(ProductModel newModel)
        {
            using (DbContextService db = new DbContextService())
            {
                ProductModel currentModel = db.products.SingleOrDefault(p => p.id == newModel.id);
                if (currentModel == null)
                {
                    return false;
                }

                currentModel.price = newModel.price;
                currentModel.count = newModel.count;
                currentModel.name = newModel.name;

                db.SaveChanges();

                return true;
            }
        }
    }
}
