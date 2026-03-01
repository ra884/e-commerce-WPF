using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace e_commerce_WPF
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        ECommerceDBEntities db=new ECommerceDBEntities();
        public ProductList(ObservableCollection<Product> p)
        {
            InitializeComponent();
            products.ItemsSource = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product p=products.SelectedItem as Product;
            NavigationService.Navigate(new ProductDetails(p));
        }
    }
}
