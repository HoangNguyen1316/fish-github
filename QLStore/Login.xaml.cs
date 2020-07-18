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
using System.Windows.Shapes;
using QLStore.BS_layer;
namespace QLStore
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        Manage_Product manage = new Manage_Product();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbName.Text == "" || lbpass.Password == "")
            {
                Dialog a = new Dialog()
                {
                    Message = "Hãy điền đầy đủ vào textbox"
                };
                a.Owner = Window.GetWindow(this);
                a.ShowDialog();
                return;
            }
            if (manage.CheckLogin(lbName.Text.Trim(), lbpass.Password.Trim()))
            {
                MainWindow b = new MainWindow(lbName.Text.Trim());
                b.Show();
                this.Close();
            }
            else
            {
                Dialog a = new Dialog()
                {
                    Message = "Thông tin chưa chính xác. Hãy điền lại"
                };
                a.Owner = Window.GetWindow(this);
                a.ShowDialog();
                lbName.Clear();
                lbpass.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Dialog a = new Dialog()
            {
                Message = "Bạn chắc chắn muốn thoát phần mềm ?"
            };
            a.Owner = Window.GetWindow(this);
            if (a.ShowDialog() == true)
                this.Close();
        }
    }
}
