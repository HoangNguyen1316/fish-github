using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLStore.BS_layer;
using QLStore.Database;
namespace QLStore.Staff_
{
    /// <summary>
    /// Interaction logic for ListStaffpage.xaml
    /// </summary>
    public partial class ListStaffpage : Page
    {
        Manage_Product manage = new Manage_Product();
        public ListStaffpage()
        {
            InitializeComponent();
            ProgressBar_.IsEnabled = true;
            ProgressBar_.Visibility = Visibility.Visible;

            Thread thread = new Thread(delegate ()
            {
                ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();

                staffs = manage.LoadData_Staff();
                Dispatcher.Invoke(() =>
                {
                    liststaff.ItemsSource = staffs;
                    ProgressBar_.IsEnabled = false;
                    ProgressBar_.Visibility = Visibility.Hidden;
                });
            });
            thread.Start();
        }

        public void Refresh(bool data)
        {
            if (data)
            {
                Thread thread = new Thread(delegate ()
                {
                    ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();
                    staffs = manage.LoadData_Staff();
                    Dispatcher.Invoke(() =>
                    {
                        liststaff.ItemsSource = staffs;
                        ProgressBar_.IsEnabled = false;
                        ProgressBar_.Visibility = Visibility.Hidden;
                    });
                });
                thread.Start();

            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewStaffPage a = new NewStaffPage();
            a.RefreshStaffList = Refresh;
            NavigationService.Navigate(a);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Dialog a = new Dialog()
            {
                Message = "Bạn chắc chắn muốn xóa thông tin này ?"
            };
            a.Owner = Window.GetWindow(this);
            if (a.ShowDialog() == false) return;
            Staff staff = liststaff.SelectedItem as Staff;
            if (staff == null) return;
            manage.DeleteStaff(staff.ID);
            Refresh(true);

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            Staff staff = liststaff.SelectedItem as Staff;
            if (staff == null) return;
            NewStaffPage a = new NewStaffPage(staff);
            a.RefreshStaffList = Refresh;
            NavigationService.Navigate(a);
        }

        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = liststaff.SelectedItem as Staff;
            if (staff != null)
            {
                var page = new InforStaff(staff);
                page.ShowDialog();
            }
        }
    }
}
