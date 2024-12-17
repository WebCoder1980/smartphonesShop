using ProductCatalog.Model;
using SmartphoneShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartphoneShop.View
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        SesseionInfo CurrentSesseionInfo { get; set; }

        public AdminPage(SesseionInfo CurrentSesseionInfo)
        {
            InitializeComponent();

            this.CurrentSesseionInfo = CurrentSesseionInfo;
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(idTextBox.Text, out int productId))
            {
                MessageBox.Show("id должен быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            ProductModel model = CurrentSesseionInfo.AdminServ.getProduct(productId);

            if (model == null)
            {
                MessageBox.Show("Товара с таким id не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            countTextBox.Text = model.count.ToString();
            priceTextBox.Text = model.price.ToString();
            nameTextBox.Text = model.name.ToString();
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(idTextBox.Text, out int productId))
            {
                MessageBox.Show("id должен быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Int32.TryParse(countTextBox.Text, out int count))
            {
                MessageBox.Show("Колличество должен быть целочисленных числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(priceTextBox.Text, out double price))
            {
                MessageBox.Show("Цена должен быть дробным числом (с запятой)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            String name = nameTextBox.Text;

            ProductModel newModel = new ProductModel();
            newModel.id = productId;
            newModel.count = count;
            newModel.price = price;
            newModel.name = name;

            CurrentSesseionInfo.AdminServ.setProduct(newModel);

            MessageBox.Show("Сохранено!");
        }
    }
}
