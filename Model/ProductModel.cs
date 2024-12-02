using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    internal class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
}
