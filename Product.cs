using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductCatalog
{
    internal partial class Product : UserControl
    {
        

        private int id;
        private string name;
        private double price;
        private int count;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                idLabel.Text = "id: " + value.ToString();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                nameLabel.Text = value.ToString();
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                priceLabel.Text = value.ToString() + " руб.";
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                countLabel.Text = "Кол-во: " + value;
            }
        }

        public Product()
        {
            InitializeComponent();
        }

        public Product(ProductModel model) : this()
        {
            Id = model.id;
            Name = model.name;
            Price = model.price;
            Count = model.count;
        }

        /*public Product(int id, string name, double price) : this()
        {
            Id = id;
            Name = name;
            Price = price;
        }*/
    }
}
