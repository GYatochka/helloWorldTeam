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


namespace ShapesPainter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pictureName;

        private MenuBar _menuBar;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

         private void Save_Click(object sender, RoutedEventArgs e)
         {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)cnv.RenderSize.Width,
                 (int)cnv.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
             rtb.Render(cnv);

             var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 250, 250));

             BitmapEncoder pngEncoder = new PngBitmapEncoder();
             pngEncoder.Frames.Add(BitmapFrame.Create(crop));

             using (var fs = System.IO.File.OpenWrite("logo.png"))
             {
                 pngEncoder.Save(fs);
             }
        }


         private void Create_Click(object sender, RoutedEventArgs e)
         {
             CreateWindow createWindow = new CreateWindow();
             createWindow.Show();
            // if (createWindow.isCreated)
            // {
                 _pictureName = createWindow.getName();
                 createWindow.Close();
             //}
        }
    }

}


