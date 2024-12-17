using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Service
{
    internal class AdminService
    {
        SesseionInfo CurrentSessionInfo { get; set; }
        public AdminService(SesseionInfo CurrentSessionInfo) {
            this.CurrentSessionInfo = CurrentSessionInfo;
        }


    }
}
