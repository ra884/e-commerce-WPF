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

namespace e_commerce_WPF
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Page
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        public Product cur_product;
        public ProductDetails(Product p)
        {
            InitializeComponent();
            title.Text = p.Name;
            price.Text = p.Price.ToString();
            desc.Text = p.Description;
            cur_product = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = db.CartItems.FirstOrDefault(x => x.User.Id == LogIn.cur_user.Id && x.ProductId == cur_product.Id);
            if (item == null)
            {
                CartItem newitem = new CartItem
                {
                    UserId = LogIn.cur_user.Id,
                    ProductId = cur_product.Id,
                    Quantity = 1
                };
                db.CartItems.Add(newitem);
                db.SaveChanges();
            }
            else
            {
                item.Quantity += 1;
                db.SaveChanges();
            }
        }

        private void view(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShoppingCart());
        }

        //    private void view(object sender, RoutedEventArgs e)
        //    {
        //        NavigationService.Navigate(new ShoppingCart());
        //    }
        //}
    }
}
