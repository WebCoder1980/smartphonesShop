using ProductCatalog.Model;
using SmartphoneShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SmartphoneShop.Service
{
    public class SesseionInfo
    {
        public BasketController BasketController { get; set; }
        public ProductService ProductServ { get; set; }

        public DbService DatabaseService { get; set; }

        public UserModel CurrentUser { get; set; }

        public MainWindow ParentWindow { get; set; }

        public SesseionInfo(MainWindow mainWindow)
        {
            ParentWindow = mainWindow;
            DatabaseService = new DbService();

            ProductServ = new ProductService(this);
            BasketController = new BasketController(this);

            CurrentUser = null;
        }

        public void Login(String name, String password)
        {
            CurrentUser = DatabaseService.login(name, password);
            
            ParentWindow.LoginEvent(name);
            ParentWindow.toProductsPage(null, null);
        }

        public void Register(String name, String password)
        {
            DatabaseService.register(name, password);

            ParentWindow.toLoginPage(null, null);
        }

        public void Logout()
        {
            CurrentUser = null;

            ParentWindow.LogoutEvent("гость");
        }
    }
}
