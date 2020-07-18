using System;
using System.Collections.ObjectModel;
using Aspose.Cells;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QLStore.BS_layer;
using QLStore.Database;
namespace QLStore.Product
{
    /// <summary>
    /// Interaction logic for ImportTypeFromExcel.xaml
    /// </summary>
    public partial class ImportTypeFromExcel : Window
    {


        ObservableCollection<Type_product> productTypes;
        public string filename;
        Manage_Product manage = new Manage_Product();

        // Delegate nhận dữ liệu từ cửa sổ Import
        public delegate void DelegateSendProductType(ObservableCollection<Type_product> Data);
        public DelegateSendProductType SendProductType;

        public ImportTypeFromExcel(string file)
        {
            filename = file;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (SendProductType != null)
            {
                SendProductType.Invoke(productTypes);
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Left = Owner.Left + Owner.Width / 2 - Width / 2;
            Top = this.Owner.Top + Owner.Height / 2 - Height / 2;

            Thread thread = new Thread(delegate ()
            {
                // Mở Excel và đọc
                Workbook workbook = new Workbook(filename);
                Worksheet worksheet = workbook.Worksheets[0];
                // Nếu import loại sản phẩm
                if (worksheet.Name.Equals("Type Product"))
                {
                    productTypes = new ObservableCollection<Type_product>();

                    // Bắt đầu từ hàng thứ 2
                    int i = 2;
                    while (worksheet.Cells[$"B{i}"].Value != null)
                    {
                        // Nếu dữ liệu đã tồn tại thì thôi
                        if (manage.getType(worksheet.Cells[$"B{i}"].Value.ToString()) != null)
                        {
                            i++;
                            continue;
                        }

                        // Kiểm tra tên, ngày có trống không
                        if (worksheet.Cells[$"A{i}"].Value == null
                            || worksheet.Cells[$"C{i}"].Value == null)
                        {
                            i++;
                            continue;
                        }

                        // Tới đây được tức có dữ liệu đã đúng
                        Type_product type = new Type_product()
                        {
                            Type_Product1 = worksheet.Cells[$"A{i}"].Value.ToString(),
                            ID = worksheet.Cells[$"B{i}"].Value.ToString(),
                            Num_Of_Product = Int32.Parse(worksheet.Cells[$"C{i}"].Value.ToString())

                        };
                        productTypes.Add(type);
                        i++;
                    }

                    // Cập nhật UI
                    Dispatcher.Invoke(() =>
                    {
                        listData.ItemsSource = productTypes;
                    });
                }
                // Nếu import sản phẩm

                // Nếu không có dữ liệu nào có thể import thì thông báo
                Dispatcher.Invoke(() =>
                {
                    if (listData.Items.Count == 0) emptyAnnounce.Visibility = Visibility.Visible;
                    ProgressBar.IsEnabled = false;
                    ProgressBar.Visibility = Visibility.Hidden;
                });
            });
            thread.Start();
        }
    }
}
