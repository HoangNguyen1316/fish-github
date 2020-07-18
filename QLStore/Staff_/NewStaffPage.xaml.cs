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
using QLStore.Supplier_;
using QLStore.BS_layer;
using QLStore.Database;

namespace QLStore.Staff_
{
    /// <summary>
    /// Interaction logic for NewStaffPage.xaml
    /// </summary>
    public partial class NewStaffPage : Page
    {

        Manage_Product manage = new Manage_Product();
        public delegate void DelegateRefeshStaffList(bool Data);
        public DelegateRefeshStaffList RefreshStaffList;
        public delegate void DelegateRefreshInfopage(Staff staff);
        public DelegateRefreshInfopage RefreshInfopage;
        bool isEdit = false;

        public NewStaffPage()
        {
            InitializeComponent();
            Title.Content = "ADD NEW STAFF";
            StaffID.Text = manage.Create_NewIdstaff_Auto();
            startwork.IsEnabled = false;
            startwork.Text = DateTime.Today.ToString();

            combosex.ItemsSource = new List<string>() { "nu", "nam" };
            comboPosition.ItemsSource = new List<string> { "quan li", "thu ngan", "ban hang" };
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,/Images/Image.png");
            image.EndInit();
            imgStaff.Source = image;
            imgStaff.Tag = null;

            StaffID.IsReadOnly = true;
            startwork.DisplayDate = DateTime.Now;
        }

        public NewStaffPage(Staff staff)
        {
            InitializeComponent();
            isEdit = true;
            Title.Content = "EDIT INFOMATION";
            StaffID.Text = staff.ID;
            StaffName.Text = staff.Name_staff;
            StaffAddress.Text = staff.Address_;
            PhoneName.Text = staff.Phone;
            startwork.Text = staff.Startwork.ToString();
            combosex.ItemsSource = new List<string>() { "nu", "nam" };
            if (staff.Sex == "nu") combosex.SelectedIndex = 0;
            else combosex.SelectedIndex = 1;

            comboPosition.ItemsSource = new List<string> { "quan li", "thu ngan", "ban hang" };
            if (staff.position == "quan li") comboPosition.SelectedIndex = 0;
            else if (staff.position == "thu ngan") comboPosition.SelectedIndex = 1;
            else comboPosition.SelectedIndex = 2;

            if (staff.Image_path != null)
            {
                BitmapImage source = new BitmapImage(new Uri(staff.Image_path));
                imgStaff.Source = source;
            }

            StaffID.IsReadOnly = true;
            BirthDate.Text = staff.Birthday.ToString();

        }



        private void BtnRefesh_Click(object sender, RoutedEventArgs e)
        {
            StaffName.Clear();
            StaffAddress.Clear();
            PhoneName.Clear();
            BirthDate.Text = "";
            comboPosition.SelectedIndex = -1;
            combosex.SelectedIndex = -1;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,/Images/Image.png");
            image.EndInit();
            imgStaff.Source = image;
            imgStaff.Tag = null;
        }

        int checkTextbox()
        {
            if (StaffID.Text == "" || StaffName.Text == "" || PhoneName.Text == "" ||
                BirthDate.Text == "" || startwork.Text == "" || StaffAddress.Text == "" || comboPosition.Text == "" ||
                combosex.Text == "" || imgStaff.Source == null)
            {
                var dialogError1 = new Dialog() { Message = "Vui lòng nhập đầy đủ các thông tin" };
                dialogError1.Owner = Window.GetWindow(this);
                dialogError1.ShowDialog();
                return 1;
            }

            return 0;
        }


        private void BtnAddStaffSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkTextbox() == 0)
            {
                var dialogError = new Dialog() { Message = isEdit ? "Xác nhận sửa thông tin?" : "Thêm mới nhân viên?" };
                dialogError.Owner = Window.GetWindow(this);
                if (dialogError.ShowDialog() == true)
                {
                    try
                    {
                        manage.AddStaff(isEdit, StaffID.Text, StaffName.Text, StaffAddress.Text, DateTime.Parse(BirthDate.Text), DateTime.Parse(startwork.Text), combosex.Text, PhoneName.Text, comboPosition.Text, imgStaff.Source.ToString());
                        if (RefreshStaffList != null)
                        {
                            RefreshStaffList.Invoke(true);
                        }


                    }
                    catch (Exception r)
                    {
                        MessageBox.Show(r.Message);
                    }

                    Staff a = new Staff();
                    a.Name_staff = StaffName.Text;
                    a.Phone = PhoneName.Text;
                    a.ID = StaffID.Text;
                    a.Address_ = StaffAddress.Text;
                    a.Birthday = DateTime.Parse(BirthDate.Text);
                    a.Startwork = DateTime.Parse(startwork.Text);
                    a.Sex = combosex.Text;
                    a.position = comboPosition.Text;
                    if (imgStaff.Source != null)
                    {
                        BitmapImage source = new BitmapImage(new Uri(imgStaff.Source.ToString()));
                        a.Image_path = source.ToString();
                    }
                    else a.Image_path = null;

                    NavigationService.Navigate(new ListStaffpage());
                    var page = new InforStaff(a);

                    page.ShowDialog();

                }
            }

        }

        private void BtnAddImageProduct_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (true == openFileDialog.ShowDialog())
            {
                string filename = openFileDialog.FileName;
                try
                {
                    BitmapImage source = new BitmapImage(new Uri(filename));
                    imgStaff.Source = source;
                    imgStaff.Tag = filename;
                }
                catch
                {
                    var dialogError = new Dialog() { Message = "Tập tin ảnh không hợp lệ" };
                    dialogError.Owner = Window.GetWindow(this);
                    dialogError.ShowDialog();
                    return;
                }

            }
        }
    }
}
