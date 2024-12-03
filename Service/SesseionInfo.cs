using SmartphoneShop.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    public class SesseionInfo
    {
        public IBasketController BasketController { get; set; }
        private SessionType CurrentSessionType { get; set; }

        public SesseionInfo(IBasketController basketController)
        {
            BasketController = basketController;
        }


    }
}
