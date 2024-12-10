using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class PanelLogin
    {
        public static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Изменить логин");
                Console.WriteLine("2. Изменить пароль");
                Console.WriteLine("3. Изменить имя");
                Console.WriteLine("4. Посмотреть данные");
                Console.WriteLine("5. Пополнить баланс");
                Console.WriteLine("6. Перейти к магазину");
                Console.WriteLine("7. Выход");

                string choice2 = Console.ReadLine();

                switch (choice2)
                {
                    case "1":
                        RegistrationServices.ChangeLogin();
                        break;

                    case "2":
                        RegistrationServices.ChangePassword();
                        break;
                    case "3":
                        RegistrationServices.ChangeName();
                        break;
                    case "4":
                        RegistrationServices.DisplayCurrentUser();
                        break;
                    case "5":
                        ReplanishBalance.ReplanBalance();
                        break;
                    case "6":
                        PanelMenu.ProductMenu();
                        break;

                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;


                }
            }



        }
    }
}
