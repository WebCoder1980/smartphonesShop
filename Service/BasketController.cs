using ProductCatalog.Model;
using SmartphoneShop.Control;
using SmartphoneShop.Model;
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
        public ObservableCollection<ProductDataGridItem> BasketItems { get; set; }

        public BasketController(SesseionInfo CurrentSesseionInfo) {
            this.CurrentSesseionInfo = CurrentSesseionInfo;
            BasketItems = new ObservableCollection<ProductDataGridItem>();
        }

        public void RefreshDataGrid()
        {
            BasketItems.Clear();
            foreach (var i in CurrentSesseionInfo.DatabaseService.GetBasketItems(CurrentSesseionInfo.CurrentUser.id))
            {
                BasketItems.Add(new ProductDataGridItem(i));
            }
        }

        public void AddItems(ObservableCollection<ProductDataGridItem> newItems)
        {
            List<BasketItemModel> newItems2 = new List<BasketItemModel>();

            foreach (var i in newItems)
            {
                BasketItemModel newModel = new BasketItemModel();
                newModel.userid = CurrentSesseionInfo.CurrentUser.id;
                newModel.productid = Int32.Parse(i.Id);
                newModel.count = Int32.Parse(i.Count);
                newItems2.Add(newModel);
            }

            CurrentSesseionInfo.DatabaseService.AddBasketItems(newItems2);
        }

        public String Buy()
        {
            List<BasketItemModel> newItems = new List<BasketItemModel>();

            foreach (var i in BasketItems.Where(i => i.IsSelected == true).ToList())
            {
                BasketItemModel newModel = new BasketItemModel();

                newModel.userid = CurrentSesseionInfo.CurrentUser.id;
                newModel.productid = Int32.Parse(i.Id);
                newModel.count = Int32.Parse(i.Count);

                newItems.Add(newModel);
            }

            String result = CurrentSesseionInfo.DatabaseService.BuyBasketItems(newItems);

            if (result != null)
            {
                return result;
            }

            RefreshDataGrid();


            return "Куплено!";
        }

        public String Delete()
        {
            List<BasketItemModel> newItems = new List<BasketItemModel>();

            foreach (var i in BasketItems.Where(i => i.IsSelected == true).ToList())
            {
                BasketItemModel newModel = new BasketItemModel();

                newModel.userid = CurrentSesseionInfo.CurrentUser.id;
                newModel.productid = Int32.Parse(i.Id);
                newModel.count = Int32.Parse(i.Count);

                newItems.Add(newModel);
            }

            CurrentSesseionInfo.DatabaseService.DeleteBasketItems(newItems);

            RefreshDataGrid();


            return "Удалено!";
        }
    }
}
