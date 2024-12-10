using ConsoleApp3;
using ConsoleApp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ReplanishBalance
    {
        public static void ReplanBalance()
        {
            Balance myBalance = new Balance();

            Console.Write("Введите сумму для пополнения баланса ");
            string input = Console.ReadLine();


            if (decimal.TryParse(input, out decimal amount))
            {
                myBalance.Replenish(amount);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите числовое значение.");
            }
            
            PanelLogin.UserMenu();
        }
    }

}
