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
    /// Interaction logic for ProductFilter.xaml
    /// </summary>
    public partial class ProductFilter : Page
    {
        ECommerceDBEntities db=new ECommerceDBEntities();
        List<Product> products;
        ObservableCollection<Product> filteredProducts=new ObservableCollection<Product>();
        public ProductFilter()
        {
            InitializeComponent();
            combo.ItemsSource=db.Products.Select(x=>x.Category).Distinct().ToList();
            products=db.Products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selected=combo.SelectedItem.ToString();
            if (selected != null)
            {
                products=products.Where(x=>x.Category==selected).ToList();
            }
            if (check.IsChecked == true)
            {
                products=products.Where(x=>x.Quantity>0).ToList();
            }
            if (price.IsChecked == true)
            {
                products=products.OrderBy(x=>x.Price).ToList();
            }
            else
            {
                products=products.OrderBy(x=>x.Name).ToList();
            }
           foreach (Product p in products)
            {
                filteredProducts.Add(p);
            }
            NavigationService.Navigate(new ProductList(filteredProducts));
        }
    }
}
