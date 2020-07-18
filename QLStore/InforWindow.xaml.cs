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

namespace QLStore
{
    /// <summary>
    /// Interaction logic for InforWindow.xaml
    /// </summary>
    public partial class InforWindow : Window
    {
        public InforWindow()
        {
            InitializeComponent();
            txbname.IsEnabled = txbMail.IsEnabled = txbAddress.IsEnabled = false;

        }

        private void Btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            txbname.IsEnabled = txbMail.IsEnabled = txbAddress.IsEnabled = false;

        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            txbname.IsEnabled = txbMail.IsEnabled = txbAddress.IsEnabled = true;

        }
    }
}
