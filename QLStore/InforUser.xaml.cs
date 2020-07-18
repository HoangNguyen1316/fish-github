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
using QLStore.BS_layer;
namespace QLStore
{
    /// <summary>
    /// Interaction logic for InforUser.xaml
    /// </summary>
    public partial class InforUser : Page
    {
        Manage_Product manage = new Manage_Product();
        public InforUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adminlog.Clear();
            adminpassold.Clear();
            adminpassnew.Clear();
        }

        private void Btnsave1_Click(object sender, RoutedEventArgs e)
        {
            if(adminlog.Text=="" || adminpassnew.Text==""|| adminpassold.Text=="")
            {
                Dialog a = new Dialog()
                {
                    Message = "Chưa điền đủ thông tin. Hãy điền lại."
                };
                a.Owner = Window.GetWindow(this);
                a.ShowDialog();
                return;
            }
            else
            {
                if(manage.ChangeLogin("admin",adminlog.Text, adminpassold.Text, adminpassnew.Text)==false)
                {
                    Dialog b = new Dialog()
                    {
                        Message = "Bạn phải nhập chính xác mật khẩu cũ ."
                    };
                    b.Owner = Window.GetWindow(this);
                    b.ShowDialog();
                }
                else
                {
                    Dialog b = new Dialog()
                    {
                        Message = "Đã đổi thành công."
                    };
                    b.Owner = Window.GetWindow(this);
                    b.ShowDialog();

                    adminlog.IsEnabled = false;
                    adminpassnew.IsEnabled = false;
                    adminpassold.IsEnabled = false;
                }
            }
        }

        private void Btnfresh2_Click(object sender, RoutedEventArgs e)
        {
            memLogin.Clear();
            memPassnew.Clear();
            memPassold.Clear();
        }

        private void BtnSave2_Click(object sender, RoutedEventArgs e)
        {
            if (memLogin.Text == "" || memPassnew.Text == "" || memPassold.Text == "")
            {
                Dialog a = new Dialog()
                {
                    Message = "Chưa điền đủ thông tin. Hãy điền lại."
                };
                a.Owner = Window.GetWindow(this);
                a.ShowDialog();
                return;
            }
            else
            {
                if (manage.ChangeLogin("member", adminlog.Text, adminpassold.Text, adminpassnew.Text) == false)
                {
                    Dialog b = new Dialog()
                    {
                        Message = "Bạn phải nhập chính xác mật khẩu cũ ."
                    };
                    b.Owner = Window.GetWindow(this);
                    b.ShowDialog();
                }
                else
                {
                    Dialog b = new Dialog()
                    {
                        Message = "Đã đổi thành công."
                    };
                    b.Owner = Window.GetWindow(this);
                    b.ShowDialog();

                    memLogin.IsEnabled = false;
                    memPassnew.IsEnabled = false;
                    memPassold.IsEnabled = false;
                }
            }
        }
    }
}
