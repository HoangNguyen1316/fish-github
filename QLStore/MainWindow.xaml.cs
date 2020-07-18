using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using QLStore.BackGroundWD;
using QLStore.Product;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using QLStore.Bill;
using QLStore.Statistic;
using QLStore.CustomerMVVM;
using System.Threading;
using QLStore.BS_layer;
using QLStore.Supplier_;
using QLStore.Database;
namespace QLStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manage_Product manage = new Manage_Product();
        MANAGEMENT_STORE_Entities db = new MANAGEMENT_STORE_Entities();
        string LoginName;
        public MainWindow(string login)
        {
            InitializeComponent();

            ObservableCollection<LoginUser> a = new ObservableCollection<LoginUser>(db.LoginUsers);
            LoginName = a[0].NameLog.Trim();
            if (login.Trim() == a[0].NameLog.Trim())
            {
                LoginName = "Admin";
                showFrame.Navigate(new HomePage());
                lbChangeAcount.IsEnabled = true;
                DardBoard.IsEnabled = true;
                loginname.Content = "Admin";
            }
            else
            {
                LoginName = "Member";
                showFrame.Navigate(new HomePage("member"));
                lbChangeAcount.IsEnabled = false;
                DardBoard.IsEnabled = false;
                loginname.Content = "Member";
            }
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            LoadMenuItemType(true);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        void LoadMenuItemType(bool data)
        {
            Manage_Product manage = new Manage_Product();

            ObservableCollection<string> a = new ObservableCollection<string>();
            a = manage.getListTypeName();
            for (int i = 0; i < a.Count; i++)
            {
                MenuItem t = new MenuItem();
                t.Header = a[i];
                t.Click += T_Click;
                typeMenu.Items.Add(t);

            }
        } 

           

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
        
             
     
        
        private void T_Click(object sender, RoutedEventArgs e)
        {

            showFrame.Navigate(new ProductPage(((MenuItem)sender).Header.ToString()));
        }

        private void A_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new ProductPage());
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (55 * 1)), 0, 0);
        }

        public void CloseConnectInputCamera()
        {
            QuickAccess tmp = showFrame.Content as QuickAccess;
            if (tmp != null)
            {

                Thread thread = new Thread(delegate ()
                {
                    if(tmp.captureDevice!=null)
                    {
                        if (tmp.captureDevice.IsRunning)
                            tmp.captureDevice.Stop();
                    }
                 
                });
                thread.Start();
            }
        }
        private void Listbillitem_PreviewMouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new ListBillPage());
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (58 * 2)), 0, 0);
        }

        private void Grid_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new StatisticPage());
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (60 * 5)), 0, 0);
        }

        private void Grid_PreviewMouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new CustomerPage());
        }

        private void Grid_PreviewMouseDown_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new CustomerPage());
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (58 * 3)), 0, 0);
        }

        private void SupplierPage_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new SupplierPage());
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (58 * 4)), 0, 0);
        }

        private void HomeItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CloseConnectInputCamera();
            showFrame.Navigate(new HomePage(loginname.Content.ToString().Trim()));
            Transitioncontent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (58 * 0)), 0, 0);
        }

      

        private void LbChangeAcount_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            showFrame.Navigate(new InforUser());
        }
    }
}
