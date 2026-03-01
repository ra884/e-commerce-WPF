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
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Page
    {
        ECommerceDBEntities db = new ECommerceDBEntities();

        public ShoppingCart()
        {
            InitializeComponent();
            items.ItemsSource = db.CartItems.Where(x => x.User.Id == LogIn.cur_user.Id).ToList();
            amount();
        }
        private void amount()
        {
            var userCart = db.CartItems
             .Where(x => x.UserId == LogIn.cur_user.Id)
             .ToList();
            decimal totalp = 0;
            foreach (var item in userCart)
            {

                decimal amount = item.Product.Price * item.Quantity;
                totalp += amount;
            }
            l_total.Content = totalp.ToString();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CartItem t = items.SelectedItem as CartItem;
            if (t != null)
            {
                if (t.Quantity>1)
                {
                    t.Quantity -= 1;
                    items.ItemsSource = db.CartItems.Where(x => x.User.Id == LogIn.cur_user.Id).ToList();
                    
                    amount();

                }
                else
                {
                
                    db.CartItems.Remove(t);
                    db.SaveChanges();
                    items.ItemsSource = db.CartItems.Where(x => x.User.Id == LogIn.cur_user.Id).ToList();
                    amount();
                }
            }
        }




        // دالة لعمل Refresh للكارت
        //private void LoadCart()
        //{
        //    var userCart = db.CartItems
        //        .Where(x => x.UserId == LogIn.cur_user.Id)
        //        .ToList();

        //    items.ItemsSource = userCart;

        //    decimal total = 0;
        //    foreach (var item in userCart)
        //    {
        //        total += item.Product.Price * item.Quantity;
        //    }

        //    l_total.Content = total.ToString();
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var item = items.SelectedItem as CartItem;
        //    if (item != null)
        //    {
        //        db.CartItems.Remove(item);
        //        db.SaveChanges();

        //        // Refresh بعد الحذف
        //        LoadCart();
        //    }
        //}
    }
}
