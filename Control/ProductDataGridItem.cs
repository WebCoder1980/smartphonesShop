using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Control
{
    class ProductDataGridItem
    {
        public bool IsSelected { get; set; }
        public string Id { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string Name { get; set; }

        public ProductDataGridItem(bool isSelected, string id, string price, string count, string name)
        {
            IsSelected = isSelected;
            Id = id;
            Price = price;
            Count = count;
            Name = name;
        }

        public ProductDataGridItem(ProductModel productModel) : this(false, productModel.id.ToString(), productModel.price.ToString(), productModel.count.ToString(), productModel.name)
        {

        }
    }
}
