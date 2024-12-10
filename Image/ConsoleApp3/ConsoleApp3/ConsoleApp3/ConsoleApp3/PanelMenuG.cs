using ConsoleApp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class PanelMenuG
    {
        public static void GuestMenu()
        {
            while (true)
            {
                
                Console.WriteLine("1. Посмотреть данные");
                Console.WriteLine("2. Перейти к магазину");
                Console.WriteLine("3. Выход");

                string choice2 = Console.ReadLine();

                switch (choice2)
                {
                    case "1":
                        RegistrationServices.DisplayCurrentUser();
                        break;
                    case "2":
                        ShopGuest.ShopProduct();
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
