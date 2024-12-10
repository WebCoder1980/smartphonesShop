using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Product
    {
        public string NameProduct { get; set; }
        public int Price { get; set; }
        public Product(string nameProduct, int price)
        {
            NameProduct = nameProduct;
            Price = price;
        }


    }
}
