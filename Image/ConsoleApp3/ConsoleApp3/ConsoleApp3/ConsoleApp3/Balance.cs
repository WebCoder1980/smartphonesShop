using ConsoleApp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Balance
    {

        public void Replenish(decimal amount)
        {
            if (amount<=0)
            {
                Console.WriteLine("Сумма пополнения должна быть положительной");
                return;
            }
            RegistrationServices.currentUser.Balance += amount;

            Console.WriteLine($"Баланс пополнен на {amount}. Текущий баланс: {RegistrationServices.currentUser.Balance}");
        }
        public void Buy(decimal amount)
        {
            RegistrationServices.currentUser.Balance -= amount;

            Console.WriteLine($"Произведена покупка на {amount}. Текущий баланс: {RegistrationServices.currentUser.Balance}");
        }
        public decimal GetBalance()
        {
            return RegistrationServices.currentUser.Balance;
        }
        public void DisplayCurrentBalance()
        {
            Console.WriteLine($"Текущий баланс: {GetBalance()}");
        }

        
        
    }

}



    
    

    

