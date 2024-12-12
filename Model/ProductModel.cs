using SmartphoneShop.Control;
using SmartphoneShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }

        public ICollection<BasketItemModel> BasketItems { get; set; }

        public ProductModel(int id, string name, double price, int count)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public ProductModel(ProductDataGridItem productDataGridItem) : this(Int32.Parse(productDataGridItem.Id), productDataGridItem.Name, Double.Parse(productDataGridItem.Price), Int32.Parse(productDataGridItem.Count))
        {

        }
    }
}
