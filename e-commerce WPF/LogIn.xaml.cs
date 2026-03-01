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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        ECommerceDBEntities db = new ECommerceDBEntities();

        public static User cur_user { get; set; }
        public LogIn()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = pass.Password;
            User user = db.Users.FirstOrDefault(x => x.Email == mail.Text);
                if (user != null && user.Password ==password)
                {
                cur_user = user;
                    NavigationService.Navigate(new ProductFilter());
                }
            }

        }
    }

