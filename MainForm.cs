using Microsoft.VisualBasic.ApplicationServices;
using ProductCatalog.Model;
using ProductCatalog.Service;

namespace ProductCatalog
{
    public partial class MainForm : Form
    {
        DbService dbService;
        public MainForm()
        {
            InitializeComponent();

            dbService = new DbService();

            List<ProductModel> products = dbService.getAllProducts();
            foreach (ProductModel product in products)
            {
                productsFLP.Controls.Add(new Product(product));
            }
        }
    }
}
