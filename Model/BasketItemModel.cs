using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Model
{
    public class BasketItemModel
    {
        public int id { get; set; }
        public string userId { get; set; }
        public int ProductId { get; set; }
        public string isBougth { get; set; }
    }
}
