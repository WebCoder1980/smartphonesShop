using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ProductServices
    {


        public static List<Product> products = new List<Product>
        {
            new Product("Яблоко", 50),
            new Product("Банан", 30),
            new Product("Апельсин", 40),
            new Product("Груша", 45),
            new Product("Киви", 60)
        };

        public static void ShowProducts()
        {
            Console.WriteLine("Список покупок: ");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.NameProduct} - {product.Price} руб.");
            }

        }

        public static bool PurchaseProduct(string productName, Balance balance)
        {
            var product = products.Find(p=> p.NameProduct.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Товар не найден");
                return false;
            }
            if (balance.GetBalance()<product.Price)
            {
                Console.WriteLine("Недостаточно средств для покупки");
                return false;
            }
            balance.Buy(product.Price);
            Console.WriteLine($"Вы купили {product.NameProduct} за {product.Price} руб");
            return true;
        }

        public static void BuyProduct(Balance balance)
        {
            
            ProductServices.ShowProducts();
            Console.WriteLine("Введите название продукта: ");
            string productName=Console.ReadLine();

            ProductServices.PurchaseProduct(productName, balance);
            balance.DisplayCurrentBalance();


        }

    }
}