using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Model
{
    public class BasketItemModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int productid { get; set; }
        public bool isbougth { get; set; }

        [ForeignKey("userid")]
        public UserModel user { get; set; }
        [ForeignKey("productid")]
        public ProductModel product { get; set; }
    }
}
