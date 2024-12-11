using ProductCatalog.Model;
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
        
        public DbService DatabaseService { get; set; }

        public UserModel CurrentUser { get; set; }

        public MainWindow ParentWindow { get; set; }

        public SesseionInfo(MainWindow mainWindow, IBasketController basketController)
        {
            DatabaseService = new DbService();
            BasketController = basketController;
            ParentWindow = mainWindow;
            CurrentUser = null;
        }

        public void Login(String name, String password)
        {
            CurrentUser = DatabaseService.login(name, password);
            
            ParentWindow.LoginEvent(name);
            ParentWindow.toProductsPage(null, null);

            BasketController = new BasketUserController((BasketGuestControoler) BasketController);
        }
    }
}
