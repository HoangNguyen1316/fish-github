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
using QLStore.Product;
using QLStore.Bill;
using QLStore.Staff_;
namespace QLStore
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public static string namestore { get; set; }

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(string member)
        {
            InitializeComponent();
            if(member=="Admin")
             btnStaff.IsEnabled = false;
            else
            {
                btnStaff.IsEnabled = true;
            }


        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new ListStaffpage());

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            InforWindow a = new InforWindow();
            a.ShowDialog();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewProductPage());
        }

        private void BtnBill_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBillPage());

        }
    }
}
