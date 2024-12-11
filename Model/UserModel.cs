using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int role { get; set; }
        public string password { get; set; }
    }
}
