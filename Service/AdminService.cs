using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    public class AdminService
    {
        SesseionInfo CurrentSessionInfo { get; set; }
        public AdminService(SesseionInfo CurrentSessionInfo) {
            this.CurrentSessionInfo = CurrentSessionInfo;
        }

        public ProductModel getProduct(int id)
        {
            return CurrentSessionInfo.DatabaseService.GetProduct(id);
        }

        public bool setProduct(ProductModel model)
        {
            return CurrentSessionInfo.DatabaseService.UpdateProduct(model);
        }
    }   
}
