using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartphoneShop.Service
{
    internal class CaptchaService
    {
        public CaptchaService()
        {

        }

        public static (String, int) Get()
        {
            (String, int) result;

            Random random = new Random();

            String expression = $"{random.Next(1, 10)} + {random.Next(1, 10)} * {random.Next(1, 5)*3}/3";

            result.Item1 = $"Проверка: сколько будет {expression}?";
            result.Item2 = (int)((double)(new DataTable().Compute(expression, "")));

            return result;
        }
    }
}
