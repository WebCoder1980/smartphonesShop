using ProductCatalog.Service;
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
        
        DbService DatabaseService { get; set; }

        String login, password;

        MainWindow ParentWindow { get; set; }

        public SesseionInfo(MainWindow mainWindow, IBasketController basketController)
        {
            DatabaseService = new DbService();
            BasketController = basketController;
            ParentWindow = mainWindow;
        }

        public void Login(String name, String password)
        {
            DatabaseService.login(name, password);

            login = name;
            this.password = password;

            ParentWindow.LoginEvent(login);
            ParentWindow.toProductsPage(null, null);
        }
    }
}
