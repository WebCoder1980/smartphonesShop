using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class User
    {
        
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateBirthday { get; set; }
        public decimal Balance { get; set; }
        public User(string login, string password, string name, string email, DateTime dateBirthday, decimal balance)
        {
            Login = login;
            Password = password;
            Name = name;
            Email = email;
            DateBirthday = dateBirthday;
            Balance = balance;
        }
        
    }
}