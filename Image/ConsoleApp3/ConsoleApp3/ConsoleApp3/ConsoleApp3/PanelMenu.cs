using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class PanelMenu
    {
        private static Balance BalanceServices { get; set; }= new Balance();
        public static void ProductMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Посмотреть список товаров");
                Console.WriteLine("2. Купить товар");
                Console.WriteLine("3. Выйти");

                string choice3 = Console.ReadLine();
                switch (choice3)
                {
                    case "1":
                        ProductServices.ShowProducts();
                        break;

                    case "2":
                        
                        ProductServices.BuyProduct(BalanceServices);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;

                }
            }
        }


    }
}
