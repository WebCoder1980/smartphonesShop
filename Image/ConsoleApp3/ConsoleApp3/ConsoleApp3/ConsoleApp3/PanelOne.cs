using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class PanelOne
    {
        public static void Panel()
        {



            while (true)
            {
                Console.WriteLine("1. Вход");
                Console.WriteLine("2. Регистрация");
                Console.WriteLine("3. Гостевой режим");
                Console.WriteLine("4. Выход");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegistrationServices.Login();
                        break;
                    case "2":
                        RegistrationServices.Registration();
                        break;
                    case "3":
                        RegistrationServices.GuestMode();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Повторите попытку");
                        break;
                }

            }

        }
    }
}
