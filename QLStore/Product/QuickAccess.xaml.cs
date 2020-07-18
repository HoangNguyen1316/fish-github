using AForge.Video;
using AForge.Video.DirectShow;
using QLStore.Background;
using QLStore.Database;
using DevExpress.Xpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QLStore.Product
{
    /// <summary>
    /// Interaction logic for QuickAccess.xaml
    /// </summary>
    public partial class QuickAccess : Page
    {
        public QuickAccess()
        {
            InitializeComponent();
        }
       public FilterInfoCollection filterInfoCollection;
        public VideoCaptureDevice captureDevice;
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
      
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            // CaptureDevice= new VideoCaptureDevice(filterInfoCollection)
              captureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
          //  captureDevice = new VideoCaptureDevice(CurrentDevice.MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            dispatcherTimer.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
           
            var bitmap = (Bitmap)eventArgs.Frame.Clone();
            var bi = bitmap.ToBitmapImage();

            // imgCameraCode.Source = bi;
            imgCameraCode.Dispatcher.Invoke(new Action(() =>
            {
                imgCameraCode.Source = BitmapToSource(bitmap);
            }));

        }

        private ImageSource BitmapToSource(Bitmap bitmap)
        {

            
            //From Aforgenet.com :)
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
          
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
        }

        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {

            if (imgCameraCode.Source!=null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                ImageSourceConverter c = new ImageSourceConverter();

                ImageSource ImaSrc = imgCameraCode.Source;
                BitmapSource BmpSrc = (BitmapSource)ImaSrc;
                Bitmap bitmapCode = GetBitmap(BmpSrc);
                Result result = barcodeReader.Decode(bitmapCode);
                if (result!=null)
                {
                    
                    #region Navigation
                    MANAGEMENT_STORE_Entities db = new MANAGEMENT_STORE_Entities();
                    string ProductNameID = result.Text;
                    Detail_Product detail = db.Detail_Product.FirstOrDefault((x) => x.ID_Product == ProductNameID);
                    if (detail != null)
                    {
                        DetailProductPage detailPage = new DetailProductPage(detail);
                        this.ReFresh();
                        if (NavigationService.CanGoBack)
                        {
                            
                            
                            NavigationService.GoBack();
                        }
                        NavigationService.Navigate(detailPage);
                        dispatcherTimer.Stop();

                        Thread thread = new Thread(delegate ()
                        {
                            if (captureDevice.IsRunning)
                                captureDevice.Stop();
                        });
                        thread.Start();
                       
                    }
                    #endregion
                  
                }
            }
        }

        private void ReFresh()
        {
            this.imgCameraCode.Source = null;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoCompressorCategory);
            captureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
            
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            
            dispatcherTimer.Start();
        }

        Bitmap GetBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(
              source.PixelWidth,
              source.PixelHeight,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(
              new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
              ImageLockMode.WriteOnly,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            source.CopyPixels(
              Int32Rect.Empty,
              data.Scan0,
              data.Height * data.Stride,
              data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }
    }
}
