using ProductCatalog.Model;
using SmartphoneShop.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartphoneShop.Service
{
    public class BasketController
    {
        public SesseionInfo CurrentSesseionInfo { get; set; }

        private ObservableCollection<ProductDataGridItem> basketItems;
        public ObservableCollection<ProductDataGridItem> BasketItems
        {
            get
            {
                if (IsUserItems == false && CurrentSesseionInfo.CurrentUser != null)
                {
                    IsUserItems = true;
                    ObservableCollection<ProductDataGridItem> tmpCollection = new ObservableCollection<ProductDataGridItem>();
                    foreach (var i in CurrentSesseionInfo.DatabaseService.GetBasketItems(CurrentSesseionInfo.CurrentUser.id))
                    {
                        tmpCollection.Add(new ProductDataGridItem(i));
                    }
                    AddItems(tmpCollection);
                }
                return basketItems;
            }

            set
            {
                basketItems = value;
            }
        }

        bool IsUserItems { get; set; }
        public BasketController(SesseionInfo CurrentSesseionInfo) {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            BasketItems = new ObservableCollection<ProductDataGridItem>();
            IsUserItems = false;
        }

        public void AddItems(ObservableCollection<ProductDataGridItem> newItems)
        {
            foreach (var i in newItems)
            {
                if (BasketItems.Where(j => j.Id == i.Id).Count() == 0)
                {
                    BasketItems.Add(i);
                    continue;
                }
                foreach (var j in BasketItems)
                {
                    if (i.Id == j.Id)
                    {
                        j.Count = (Int32.Parse(i.Count) + Int32.Parse(j.Count)).ToString();
                    }
                }
            }
        }

        public String Buy()
        {
            if (CurrentSesseionInfo.CurrentUser == null)
            {
                return "Войдите в систему, что бы купить!";
            }

            BasketItems.Where(i => i.IsSelected == true).ToList().All(i => BasketItems.Remove(i));
            return "Куплено!";
        }

        public String Delete()
        {
            BasketItems.Where(i => i.IsSelected == true).ToList().All(i => BasketItems.Remove(i));
            return "Удалено!";
        }
    }
}
