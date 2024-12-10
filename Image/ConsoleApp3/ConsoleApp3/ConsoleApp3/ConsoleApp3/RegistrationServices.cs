using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class RegistrationServices
    {
        private static List<User> users = new List<User>();
        public static User currentUser = new User("Гость", "Гостевой_Пароль", "", "", DateTime.MinValue, 0);
        public static void Login()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    currentUser = user;
                    Console.WriteLine("Вход выполнен успешно!");
                    PanelLogin.UserMenu();
                    return;
                }
            }
            Console.WriteLine("Неверный логин или пароль");
        }
        public static void Registration()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();

            if (ContainsLogin(login))
            {
                Console.WriteLine("Логин уже занят");
                return;
            }
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            Console.WriteLine("Подтвердите пароль");
            string confirmPassword = Console.ReadLine();

            if (password != confirmPassword)
            {
                Console.WriteLine("Пароли не совпадают. Попробуйте снова.");
                return;
            }


            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите дату рождения (yyyy-mm-dd):");
            string dateInput = Console.ReadLine();
            DateTime dateBirthday;
            string email = GetEmail();

            Console.WriteLine($"Вы ввели коректную почту {email}");
            static string GetEmail()
            {
                string email;
                while (true)
                {
                    Console.WriteLine("Введите почту:");
                    email = Console.ReadLine();

                    if (IsValidEmail(email))
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введённый адрес электронной почты некорректен. Пожалуйста, попробуйте снова.");
                    }
                }
                return email;
            }

            static bool IsValidEmail(string email)
            {
                try
                {
                    new System.Net.Mail.MailAddress(email);
                } catch(Exception e) {
                    return false;
                }

                return true;
            }
            if (DateTime.TryParse(dateInput, out dateBirthday))
            {
                User newUser = new User(login, password, name, email, dateBirthday, 0);
                users.Add(newUser);
                Console.WriteLine("Регистрация прошла успешно!");
                currentUser = newUser;
                PanelLogin.UserMenu();

            }
            else
            {
                Console.WriteLine("Некорректный формат даты. Попробуйте еще раз.");
            }
            
        }
       
    
        public static void GuestMode()

        {
            Console.WriteLine("Вы вошли в гостевой режим.");
            currentUser = new User("Гость", "Гостевой_Пароль", "", "", DateTime.MinValue, 0);
            PanelMenuG panelMenuG = new PanelMenuG();
            PanelMenuG.GuestMenu();
        }



        public static void ChangeLogin()
        {
            Console.WriteLine("Введите новый логин");
            string newLogin = Console.ReadLine();

            if (ContainsLogin(newLogin))
            {
                Console.WriteLine("Логин уже занят.Попробуйте снова");
                return;
            }

            
            currentUser.Login = newLogin;
            users.Add(currentUser);
            Console.WriteLine("Логин изменен успешно!");
        }
        public static void ChangeName()
        {
            Console.WriteLine("Введите новое имя");
            string newName = Console.ReadLine();


            users.Remove(currentUser);
            currentUser.Name = newName;
            users.Add(currentUser);
            Console.WriteLine("Логин изменен успешно!");
        }
        public static void ChangePassword()
        {
            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine();
            Console.WriteLine("Подтвердите новый пароль:");
            string confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Пароли не совпадают. Попробуйте снова.");
                return;
            }

            
            currentUser.Password = newPassword;
            users.Add(currentUser);
            Console.WriteLine("Пароль изменен успешно!");
        }

        public static void DisplayCurrentUser()
        {

            Console.WriteLine($"Текущий пользователь: Логин - {currentUser.Login}, Пароль - {currentUser.Password}, Имя - {currentUser.Name}, Почта - {currentUser.Email}, Дата рождения - {currentUser.DateBirthday}");
        }

        
        public static bool ContainsLogin(string login)
        {
            foreach (User user in users)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }
    }
}

