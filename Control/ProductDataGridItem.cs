using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneShop.Control
{
    public class ProductDataGridItem : INotifyPropertyChanged
    {
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public string Id { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string Name { get; set; }

        public ProductDataGridItem(bool isSelected, string id, string price, string count, string name)
        {
            IsSelected = isSelected;
            Id = id;
            Price = price;
            Count = count;
            Name = name;
        }

        public ProductDataGridItem(ProductModel productModel) : this(false, productModel.id.ToString(), productModel.price.ToString(), productModel.count.ToString(), productModel.name)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
