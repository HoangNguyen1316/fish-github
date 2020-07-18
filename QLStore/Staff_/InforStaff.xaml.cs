using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using QLStore.Database;
using QLStore.BS_layer;

namespace QLStore.Staff_
{
    /// <summary>
    /// Interaction logic for InforStaff.xaml
    /// </summary>
    public partial class InforStaff : Window
    {
        public Staff staff = new Staff();
        public InforStaff()
        {
            InitializeComponent();
        }
        public InforStaff(Staff t)
        {
            InitializeComponent();

            Thread A = new Thread(delegate ()
            {


                this.staff = t;
                Dispatcher.Invoke(() =>
                {
                    txbName.Text = staff.Name_staff;
                    txbID.Text = staff.ID;
                    txbPhone.Text = staff.Phone;
                    txbPos.Text = staff.position;
                    txbsex.Text = staff.Sex;
                    txbStart.Text = staff.Startwork.ToString();
                    txbBirth.Text = staff.Birthday.ToString();
                    txbsex.Text = staff.Sex;
                    txbAddress.Text = staff.Address_;
                    if (staff.Image_path != null)
                    {
                        BitmapImage source = new BitmapImage(new Uri(staff.Image_path));
                        img.Source = source;
                    }
                    ProgressBar.IsEnabled = false;
                    ProgressBar.Visibility = Visibility.Hidden;
                });


            });
            A.Start();


        }

        private void Btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
