using ConsoleApp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ShopGuest
    {
        public static void ShopProduct()
        {
            while (true)
            {
                Console.WriteLine("1. Посмотреть список товаров");
                Console.WriteLine("2. Выйти");

                string choice3 = Console.ReadLine();
                switch (choice3)
                {
                    case "1":
                        ProductServices.ShowProducts();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;

                }
            }
        }
    }
}
